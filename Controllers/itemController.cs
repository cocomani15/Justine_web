using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using justine_webapp.Data;
using justine_webapp.Models;

namespace justine_webapp.Controllers
{
    public class itemController : Controller
    {
        private readonly ApplicationDbContext _db;
        public itemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult itm ()
        {
            IEnumerable<item> objitem = _db.items;
            return View(objitem);
        }[HttpGet]
        public IActionResult newfile()
        {
            return View();
        }[HttpPost]
        public IActionResult newfile (item itms)
        {
            if(ModelState.IsValid)
            {
                _db.items.Add(itms);
                _db.SaveChanges();
                return RedirectToAction("itm");
            }
            return View();
        }

   }
}