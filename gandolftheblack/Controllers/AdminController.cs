using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gandolftheblack.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _db;
        public AdminController(AppDbContext db) => _db = db;

        public async Task<IActionResult> Requests(string status = "All")
        {
            var query = _db.ResourceRequests.AsQueryable();
            if (status != "All")
                query = query.Where(r => r.Status == status);   

            var list = await query
                .OrderByDescending(r => r.CreatedUtc)  
                .Include(r => r.Requester)
                .ToListAsync();
            ViewBag.Status = status;
            return View(list);
        }

        public async Task<IActionResult> View(int id)
        {
            var req = await _db.ResourceRequests.FindAsync(id);
            return req == null ? NotFound() : View(req);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Accept(int id)
        {
            var req = await _db.ResourceRequests.FindAsync(id);
            req.Status = "Accepted";
            await _db.SaveChangesAsync();   
            
            return RedirectToAction(nameof(View), new { id = id });
        }

        // POST /Admin/Deny/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Deny(int id)
        {
            var req = await _db.ResourceRequests.FindAsync(id);
            req.Status = "Rejected";
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(View), new { id = id });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DenyOut(int id)
        {
            var req = await _db.ResourceRequests.FindAsync(id);
            req.Status = "Rejected";
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Requests));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AcceptOut(int id)
        {
            var req = await _db.ResourceRequests.FindAsync(id);
            req.Status = "Accepted";
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Requests));
        }

        [HttpPost]
        public async Task<IActionResult> Assign(int id)
        {
            var req = await _db.ResourceRequests.FindAsync(id);
            req.Status = "Assigned";
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(View), new { id = id });
        }

        // POST /Admin/Assign
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(int id, string network, string security, string manager)
        {
            var req = await _db.ResourceRequests.FindAsync(id);
            if (req == null) return NotFound();

            req.NetworkEngineer = network;
            req.SecurityEngineer = security;
            req.Manager = manager;
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(View), new { id = id });

        }
    }
}
