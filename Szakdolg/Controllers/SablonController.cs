using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Szakdolg.Models;

namespace Szakdolg.Controllers
{
    [Authorize(Roles = "Admin")]
    [AllowAnonymous]
    public class SablonController : Controller
    {
        
        readonly ApplicationDbContext _context;

        public SablonController() => _context = new ApplicationDbContext();
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var sabl = _context.Sablonok.ToList();
            return View(sabl);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Mentes(Sablonok sablonok)
        {
            if (sablonok.Id == null || sablonok.Id == 0)
            {
                _context.Sablonok.Add(sablonok);
            }
            else
            {
                var adott = _context.Sablonok.Single(u => u.Id == sablonok.Id);
                adott.Megnevezes = sablonok.Megnevezes;
                adott.Ar = sablonok.Ar;
                adott.Img = sablonok.Img;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Sablon");
        }
        public ActionResult Modositas(int id)
        {
            var sablon = _context.Sablonok.SingleOrDefault(u => u.Id == id);
            if (sablon == null) return HttpNotFound();
            var vm = new SablonModel()
            {
                Sablonok = sablon
            };
            return View("Modositas", vm);
        }
        public ActionResult Delete(int id)
        {
            var sablon = _context.Sablonok.Find(id);
            if (sablon == null) return HttpNotFound();
            _context.Sablonok.Remove(sablon);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Uj()
        {
            return View("Uj");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UjMentes(HttpPostedFileBase postedFile, Sablonok sablonok)
        {
            
            if (postedFile.ContentLength > 0)
            {
                string _FileName = Path.GetFileName(postedFile.FileName);
                string _path = Path.Combine(Server.MapPath("~/Content/Img"), _FileName);
                postedFile.SaveAs(_path);
                sablonok.Img = _FileName;
              
                _context.Sablonok.Add(sablonok);
                _context.SaveChanges();
                return RedirectToAction("Index", "Sablon");
            }
            return View("Index");
        }
    }
}