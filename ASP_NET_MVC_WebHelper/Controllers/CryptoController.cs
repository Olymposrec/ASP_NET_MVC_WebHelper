using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ASP_NET_MVC_WebHelper.Controllers
{
    public class CryptoController : Controller
    {
        private string sifresiz = "Melih (Olymposrec) Akkose";
        private string sifreli= "ALP+ZEkidOz7aWSofxNmFWCMOV9NJ001K+fKP8zI+eN2rVM6s+QltDX/5bZ22wAJYQ=="; // HashPassWord(sifresiz);
        // GET: Crypto
        public ActionResult Index()
        {
            string salt = Crypto.GenerateSalt();

            string hash = Crypto.Hash(sifresiz);
            string sh1 = Crypto.SHA1(sifresiz);
            string sh256 = Crypto.SHA256(sifresiz);

            string sonuc = Crypto.HashPassword(sifresiz);
            bool isThatTrue = Crypto.VerifyHashedPassword(sifreli, sifresiz);
            return View();
        }
    }
}