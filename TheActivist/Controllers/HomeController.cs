using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheActivist.Data;
using TheActivist.Models;

namespace TheActivist.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private readonly AuthDbContext _db;

        [ActivatorUtilitiesConstructor]
        public HomeController(AuthDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<CauseClass> objCauseList = _db.CauseClasses;

            var obj = from s in objCauseList orderby s.CausesId descending select s; 

            return View(obj);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}