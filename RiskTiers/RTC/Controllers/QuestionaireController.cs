using Microsoft.AspNetCore.Mvc;
using RTC.Models;
using System.Threading.Tasks;

namespace RTC.Controllers
{
    public class RTCController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RTCController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserResponse userResponse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userResponse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ThankYou));
            }
            return View(userResponse);
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
