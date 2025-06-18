using vdl.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<ResourceRequest> ResourceRequests { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed an admin and a user with hashed passwords
        var hasher = new PasswordHasher<User>();

        var admin = new User
        {
            Id = 1,
            Email = "admin.vdl@gmail.com",
            PasswordHash = hasher.HashPassword(null, "admin123"),
            Role = "Admin"
        };

        var user = new User
        {
            Id = 2,
            Email = "vdl@gmail.com",
            PasswordHash = hasher.HashPassword(null, "pass123"),
            Role = "User"
        };

        var user2 = new User
        {
            Id = 3,
            Email = "user@gmail.com",
            PasswordHash = hasher.HashPassword(null, "pass123"),
            Role = "User"
        };


        modelBuilder.Entity<User>().HasData(admin, user, user2);
    }
}
