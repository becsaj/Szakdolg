using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Szakdolg.Controllers
{
    [AllowAnonymous]
    public class BemutatkozasController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
    }
}