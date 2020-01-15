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
    public class MunkaController : Controller
    {
        readonly ApplicationDbContext _context;

        public MunkaController() => _context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var munk = _context.Munkaim.ToList().OrderByDescending(s => s.Elkeszult);
            return View(munk);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Mentes(Munka munkaim)
        {
            if (!ModelState.IsValid)
            {
                var vm = new MunkaModel
                {
                    Munkaim = munkaim
                };

                return View("Modositas", vm);
            }

            if (munkaim.Id == null || munkaim.Id == 0)
            {
                _context.Munkaim.Add(munkaim);
            }
            else
            {
                var adott = _context.Munkaim.Single(u => u.Id == munkaim.Id);
                adott.Nev = munkaim.Nev;
                adott.Elkeszult = munkaim.Elkeszult;
                adott.Img = munkaim.Img;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Munka");
        }
        public ActionResult Modositas(int id)
        {
            var munka = _context.Munkaim.SingleOrDefault(u => u.Id == id);
            if (munka == null) return HttpNotFound();
            var vm = new MunkaModel()
            {
                Munkaim = munka
            };
            return View("Modositas", vm);
        }
        public ActionResult Delete(int id)
        {
            var munka = _context.Munkaim.Find(id);
            if (munka == null) return HttpNotFound();
            _context.Munkaim.Remove(munka);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Uj()
        {
            return View("Uj");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UjMentes(HttpPostedFileBase postedFile, Munka munkaim)
        {
            if (postedFile.ContentLength > 0)
            {
                string _FileName = Path.GetFileName(postedFile.FileName);
                string _path = Path.Combine(Server.MapPath("~/Content/Img"), _FileName);
                postedFile.SaveAs(_path);
                munkaim.Img = _FileName;
                if (!ModelState.IsValid)
                {
                    var vm = new MunkaModel
                    {
                        Munkaim = munkaim
                    };
                    return View("Uj", vm);
                }
                _context.Munkaim.Add(munkaim);
                _context.SaveChanges();
                return RedirectToAction("Index", "Munka");
            }
            return View("Index");
        }
    }
}