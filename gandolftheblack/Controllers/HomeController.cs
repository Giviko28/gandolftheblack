using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using gandolftheblack.Models;
using gandolftheblack.ViewModels;
using gandolftheblack.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace gandolftheblack.Controllers;

[Authorize(Roles = "User")]
public class HomeController : Controller
{
    private readonly AppDbContext _db;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, AppDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        return View(new ResourceRequestViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(ResourceRequestViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        var userEmail = User.Identity!.Name!;
        var user = _db.Users.Single(u => u.Email == userEmail);

        var request = new ResourceRequest
        {
            RequesterId = user.Id,
            ResourceType = vm.ResourceType,
            Reason = vm.Reason,
            Duration = vm.Duration,
            Notes = vm.Notes
        };

        _db.ResourceRequests.Add(request);
        _db.SaveChanges();

        TempData["Success"] = "Request submitted!";
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> MyRequests()
    {
        var email = User.Identity!.Name!;
        var requests = await _db.ResourceRequests
            .Where(r => r.Requester != null && r.Requester.Email == email)
            .OrderByDescending(r => r.CreatedUtc)
            .ToListAsync();

        return View(requests);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
