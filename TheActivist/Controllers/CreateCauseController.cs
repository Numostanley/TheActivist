using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheActivist.Data;
using TheActivist.Models;

namespace TheActivist.Controllers
{

    //The codes for this controller were aided through the git repository : https://github.com/Numostanley/BulkyBook.git
   
    [Authorize]
    public class CreateCauseController : Controller
    {
     
        private readonly AuthDbContext _db;

        [ActivatorUtilitiesConstructor]
        public CreateCauseController(AuthDbContext db)
        {
            _db = db;
        }

        public CauseClass Model { get; set; }

        //Get
        public IActionResult Index()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CauseClass cause)
        {
            if (ModelState.IsValid)
            {
                _db.CauseClasses.Add(new CauseClass
                {
                    CausesName = cause.CausesName,
                    CausesDescription = cause.CausesDescription,
                    CreatedBy = User.Identity.Name,
                });
                _db.SaveChanges();
                TempData["Success"] = "Cause created successfully.";
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View();
        }

        //Get
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.CauseClasses.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            //Tuple<CauseClass, SignedCause>? data = new Tuple<CauseClass, SignedCause>(categoryFromDb, (SignedCause)signedCauses);

            return View(categoryFromDb);
        }

        public IActionResult Signed(int? id)
        {
            IEnumerable<SignedCause> objSignedList = _db.SignedCauses;

            var categoryFromDb = _db.CauseClasses.Find(id);

            var obj = from s in objSignedList where s.CauseName == categoryFromDb.CausesName orderby s.Id descending select s;

            return View(obj);
        }

        //Get
        public IActionResult Sign(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.CauseClasses.Find(id);
            //var categoryFromDb = _db.Categories.SingleOrDefault(c => c.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Sign")]
        [ValidateAntiForgeryToken]
        public IActionResult SignPost(int? id)
        {
            var obj = _db.CauseClasses.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.SignedCauses.Add(new SignedCause
                {
                    CauseName = obj.CausesName,
                    UserName = User.Identity.Name,
                });

                _db.SaveChanges();

                TempData["Success"] = "Cause signed successfully.";

                return RedirectToAction("Details", new { id = id });
            }
                //TempData["Error"] = "Sorry, you have already signed this Cause";
                //return RedirectToAction("Details", new { id = id });
            
            return View(obj);
        }


        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.CauseClasses.Find(id);
            //var categoryFromDb = _db.Categories.SingleOrDefault(c => c.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.CauseClasses.Find(id);

            var user = _db.Users.FirstOrDefault(c => c.UserName == User.Identity.Name);
            var IsAdmin = user.Is_Admin;


            if (obj == null)
            {
                return NotFound();
            }

            if (IsAdmin == true)
            {
                _db.CauseClasses.Remove(obj);
                _db.SaveChanges();
                TempData["Success"] = "Cause deleted successfully.";
                
            }
            else
            {
                TempData["Error"] = "Sorry, You are not an Admin";
                return RedirectToAction("Details", new { id = id });
            }
            return RedirectToAction("Details", new { id = id });
        }
    }
}
