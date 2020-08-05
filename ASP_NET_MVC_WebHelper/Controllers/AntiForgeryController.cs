using ASP_NET_MVC_WebHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC_WebHelper.Controllers
{
    public class AntiForgeryController : Controller
    {
        // GET: AntiForgery
        public ActionResult Test()
        {
            return View(Veritabani.veriler);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Test(int id)
        {
            Veritabani.veriler.RemoveAt(id-1);
            return RedirectToAction("Test");
        }
        public ActionResult FakeTest()
        {
            return View();
        }
    }
}