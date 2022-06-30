using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using justine_webapp.Data;
using justine_webapp.Models;
using justine_webapp.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace justine_webapp.Controllers
{
    public class TypeController: Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public TypeViewModel TypeVM { get; set; }

        public TypeController(ApplicationDbContext database)
        {
            _db = database;
           TypeVM= new TypeViewModel()
            {
                Items = _db.items.ToList(),
                Type = new Models.Type()
            };
        }
        [HttpGet]
        public IActionResult types()
        {
           var typ = _db.types.Include(x => x.item);
            return View(typ);
        }
        // [HttpGet]
        // public IActionResult NewType()
        // {
        //     return View();
        // }
        // [HttpGet]
        // public IActionResult EditType(int idtype)
        // {
        //      _db.types.Find(idtype);
        //     _db.SaveChanges();
        //     return View();
        // }
        // [HttpPost]
        // public IActionResult EditType(Type tp)
        // {
        //     if(ModelState.IsValid)
        //     {
        //         _db.types.Update(tp);
        //         _db.SaveChanges();
        //         return RedirectToAction("types");
        //     }
        //     return View();
        // }
        // public IActionResult NewType (Type tpys)
        // {
        //     if(ModelState.IsValid)
        //     {
        //         _db.types.Add(tpys);
        //         _db.SaveChanges();
        //         return RedirectToAction("types");
        //     }
        //     return View();
        // }
        [HttpGet]
        public IActionResult TypeViewModel()
        {
            return View(TypeVM);
        }
        [HttpPost]
        [ActionName("TypeViewModel")]
        public IActionResult TypeViewModePost()
        {
            if(ModelState.IsValid)
            {
                _db.types.Add(TypeVM.Type);
                _db.SaveChanges();
                return RedirectToAction("types");
           
            }  
            return View(TypeVM);
        }
    }
}