using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using justine_webapp.Data;
using justine_webapp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace justine_webapp.Controllers
{
    public class InstrumentController : Controller
    {
        [BindProperty]
        public InstrumentViewModel instrumentVM { get; set; }
        private readonly IWebHostEnvironment webhost;
        private readonly ApplicationDbContext _db;

        public InstrumentController(ApplicationDbContext database, IWebHostEnvironment webhostenv)
        {
            _db = database;
            webhost = webhostenv;
            instrumentVM = new InstrumentViewModel()
            {
                Items = _db.items.ToList(),
                types = _db.types.ToList(),
                instrument = new Models.Instrument()
            };
        }
        [HttpGet]
        public IActionResult instrument()
        {
            var instru = _db.instrument.Include(x => x.Item).Include(x => x.Type);
            return View(instru);
        }

        [ActionName("DeleteView")]
        public IActionResult DeleteViewPost(int ID)
        {
            var del = _db.instrument.Find(ID);
            if (del == null)
            {
                return NotFound();
            }
            _db.instrument.Remove(del);
            _db.SaveChanges();
            return RedirectToAction("Instrument");
        }
       [HttpPost]
        [ActionName("Edit")]

        [HttpGet]
        public IActionResult EditView(int ID)
        {
            instrumentVM.instrument = _db.instrument.Include(x => x.Item).Include(x => x.Type).SingleOrDefault(x => x.Id == ID);

            if (instrumentVM.instrument == null)
            {
                return NotFound();
            }
            return View(instrumentVM);
        }
        private void SaveImages()
        {
            _db.instrument.Add(instrumentVM.instrument);
            _db.SaveChanges();

            var instrumentID = instrumentVM.instrument.Id;
            string rootpath = webhost.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var save = _db.instrument.Find(instrumentID);

            if (files.Count() != 0)
            {
                var imagepath = @"images\Instrument\";
                var extn = Path.GetExtension(files[0].FileName);
                var relativeimgPath = imagepath + instrumentID + extn;
                var AbsPathImage = Path.Combine(rootpath, relativeimgPath);

                using (var FileStreams = new FileStream(AbsPathImage, FileMode.Create))
                {
                    files[0].CopyTo(FileStreams);
                }
                save.ImagePath = relativeimgPath;
                _db.SaveChanges();
            }
        }
        [HttpGet]
        [ActionName("EditView")]
        public IActionResult EditViewPost()
        {
            if (ModelState.IsValid)
            {
                _db.Update(instrumentVM.instrument);
                SaveImages();
                _db.SaveChanges();
                return RedirectToAction("InstrumentView");
            }
            return View(instrumentVM);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(instrumentVM);
        }
        [HttpPost]
        [ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (ModelState.IsValid)
            {
                _db.instrument.Add(instrumentVM.instrument);
                _db.SaveChanges();

                var instrumentID = instrumentVM.instrument.Id;
                string rootpath = webhost.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var save = _db.instrument.Find(instrumentID);

                if (files.Count() != 0)
                {
                    var imagepath = @"images\Instrument\";
                    var extn = Path.GetExtension(files[0].FileName);
                    var relativeimgPath = imagepath + instrumentID + extn;
                    var AbsPathImage = Path.Combine(rootpath, relativeimgPath);

                    using (var FileStreams = new FileStream(AbsPathImage, FileMode.Create))
                    {
                        files[0].CopyTo(FileStreams);
                    }
                    save.ImagePath = relativeimgPath;
                    _db.SaveChanges();
                }
               
                return RedirectToAction("instrument");

            }
             return View(instrumentVM);
        }
        


            [HttpGet]
             public IActionResult newfile()
             {
                return View();
             }[HttpPost]
             public IActionResult newfile (item itms)
            {
                if(ModelState.IsValid)
                 {
                    _db.items.Add(itms);
                    return RedirectToAction("itm");
                 }
                 return View();
             }

        }
    }