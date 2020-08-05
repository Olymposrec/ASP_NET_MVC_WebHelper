using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ASP_NET_MVC_WebHelper.Controllers
{
    public class WebMailController : Controller
    {
        // GET: WebMail
        public ActionResult Index()
        {
            bool sonuc = false;
            WebMail.SmtpServer = "smtp.outlook.com";
            WebMail.SmtpPort = 587;
            WebMail.UserName = "mailadresi@hotmail.com";
            WebMail.Password = "mailsifresi";
            WebMail.EnableSsl = true;
            string file = Server.MapPath("~/Images/1006255.jpg");

            try
            {
                WebMail.Send(
                    to: "mailadresi@hotmail.com", subject: "Web Mail Test",
                    body: "Bu bir deneme mailidir. Dikkate almayınız...",
                    isBodyHtml:true,
                    filesToAttach:new[] { file});
                    //filesToAttach: new[] { file }); 
                sonuc = true;
            }
            catch(Exception ex)
            {
                ViewBag.Hata = ex.Message;
            }
            ViewBag.Sonuc = sonuc;



            return View();
        }
    }
}