using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ASP_NET_MVC_WebHelper.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChartGoster(string tip = "Column",string cache="chart1")
        {
            Chart chart = Chart.GetFromCache(cache);
            if (chart == null)
            {
                chart = new Chart(500, 500);
                chart.AddLegend("Detaylar");
                chart.AddTitle("Vega - Web Sitesi Satış Grafiği");
                chart.AddSeries(name: "Site - 1", chartType: tip,
                    xValue: new[] { 20, 40, 60, 80, 100 },
                    yValues: new[] { 10000, 20000, 30000, 40000, 50000 });
                chart.AddSeries(name: "Site - 2", chartType: tip,
                    xValue: new[] { 20, 40, 60, 80, 100 },
                    yValues: new[] { 13687, 20421, 35461, 48512, 50123 });
                string dir = Server.MapPath("~/charts/");
                if (Directory.Exists(dir) == false)
                {
                    Directory.CreateDirectory(dir);
                }
                string imagePath = dir + "chart1.jpeg";
                string xmlPath = dir + "chart1.xml";
                chart.Save(imagePath, format: "jpeg");
                chart.SaveXml(xmlPath);

                chart.SaveToCache(cache, 10, true);
            }




            return View(chart);
        }
        public ActionResult ChartGoster2(string tip = "Pie", string cache = "chart2")
        {
            Chart chart = Chart.GetFromCache(cache);
            if (chart == null)
            {
                chart = new Chart(500, 500);
                chart.AddLegend("Detaylar");
                chart.AddTitle("Vega - Web Sitesi Satış Grafiği");
                chart.AddSeries(name: "Pie Graph", chartType: tip,
                    xValue: new[] { "Site - 1","Site - 2","Site - 3","Site - 4","Site - 5"},
                    yValues: new[] { 10000, 20000, 30000, 40000, 50000 });
                
                string dir = Server.MapPath("~/charts/");
                if (Directory.Exists(dir) == false)
                {
                    Directory.CreateDirectory(dir);
                }
                string imagePath = dir + "chart2.jpeg";
                string xmlPath = dir + "chart2.xml";
                chart.Save(imagePath, format: "jpeg");
                chart.SaveXml(xmlPath);

                chart.SaveToCache(cache, 1, true);
            }




            return View("ChartGoster",chart);
        }
    }
}