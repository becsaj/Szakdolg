using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Szakdolg.Models;

namespace Szakdolg.Controllers
{
    public class IntezoFeedBackController : Controller
    {
        readonly ApplicationDbContext _context;
        public IntezoFeedBackController() => _context = new ApplicationDbContext();
        public ActionResult Index()
        {
            var feedback = _context.FeedBack.Where(f => f.Engedelyezett == false).ToList().OrderByDescending(s => s.Id);
            return View(feedback);

        }
        public ActionResult Engedelyez(int id)
        {
            var feedback = _context.FeedBack.SingleOrDefault(u => u.Id == id);
            if (feedback == null) return HttpNotFound();
            feedback.Lattamozott = true;
            feedback.Engedelyezett = true;
            _context.SaveChanges();
            return RedirectToAction("Index", "IntezoFeedBack");
        }
        public ActionResult Torles(int id)
        {
            var feedback = _context.FeedBack.Find(id);
            if (feedback == null) return HttpNotFound();
            _context.FeedBack.Remove(feedback);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}