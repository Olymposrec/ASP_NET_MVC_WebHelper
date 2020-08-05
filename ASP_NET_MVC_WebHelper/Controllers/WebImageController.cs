using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;

namespace ASP_NET_MVC_WebHelper.Controllers
{
    public class WebImageController : Controller
    {
        // GET: WebImage
       
        public string ImagePath
        {
            get { return Server.MapPath("~/Images/1006255.jpg"); }
        }
        public ActionResult Start(string cmd="original")
        {
            ViewBag.cmd = cmd;
            return View();
        }
        public void Process(string p)
        {
            WebImage image = new WebImage(this.ImagePath);
            switch (p)
            {
                case "Original":
                    break;
                case "RotateLeft":
                    image.RotateLeft();
                    break;
                case "RotateRight":
                    image.RotateRight();
                    break;
                case "FlipHorizontal":
                    image.FlipHorizontal();
                    break;
                case "FlipVertical":
                    image.FlipVertical();
                    break;
                case "Resize":
                    image.Resize(image.Width / 2, image.Height / 2, preserveAspectRatio: true);
                    break;
                case "AddTextWatermark":
                    image.AddTextWatermark("Olymposrec", fontColor: "Black", fontSize: 14, horizontalAlign: "Center",
                        verticalAlign: "Bottom");
                    break;
                case "AddImageWatermark":
                    WebImage watermark = new WebImage(this.ImagePath);
                    watermark.Resize(50, 50);
                    watermark = watermark.Save(Server.MapPath("~/Images/watermark.jpg"), imageFormat: "jpg");

                    image.AddImageWatermark(watermark.FileName, 50, 50, verticalAlign: "Top",opacity:75);
                    break;
                case "Crop":
                    image.Crop(0, 0, 100, 100);
                    break;
                default:
                    break;

            }
            string savePath = Server.MapPath("~/Images/last.jpg");
            //WebImage savedimage = image.Save(savePath, imageFormat: "jpeg");
            image.Write();
        }
    }
}