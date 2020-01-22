using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Szakdolg.Models;

namespace Szakdolg.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        readonly ApplicationDbContext _context;
        public NotificationController() => _context = new ApplicationDbContext();
        public ActionResult Feedback()
        {
            var lattamazott = _context.FeedBack.Where((u => u.Lattamozott == false)).Count();

            return Content(lattamazott.ToString());
        }
        public ActionResult Konzul()
        {
            var lattamazott = _context.Konzul.Where((u => u.Lattamozott == false)).Count();

            return Content(lattamazott.ToString());
        }
    }
}