using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BiletApp.Data;

namespace BiletApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _context.Events
                .Include(e => e.Category)
                .OrderByDescending(e => e.EventDate)
                .Take(6)
                .ToListAsync();
            
            ViewBag.TotalEvents = await _context.Events.CountAsync();
            ViewBag.TotalTickets = await _context.Tickets.CountAsync();
            ViewBag.TotalOrders = await _context.Orders.CountAsync();
            
            return View(events);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}

