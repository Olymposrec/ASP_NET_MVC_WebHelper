using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ASP_NET_MVC_WebHelper.Controllers
{
    public class WebCacheController : Controller
    {
        // GET: WebCache
        public ActionResult Index()
        {
            string time = WebCache.Get("zaman");
            if(string.IsNullOrEmpty(time))
            {
                time = DateTime.Now.ToString();
                WebCache.Set(key: "zaman", value: time, minutesToCache: 1, slidingExpiration: true);
            }
            ViewBag.simdi = time;
            return View();
        }
        public ActionResult RemoveCache()
        {
            WebCache.Remove("zaman");
            return RedirectToAction("Index");
           
        }
    }
}