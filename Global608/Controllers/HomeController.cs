using Global608.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Global608.Controllers
{
    public class HomeController : Controller
    {

        private readonly Ftis2023Context _db;

        public HomeController(Ftis2023Context db) { _db = db; }


        public IActionResult Index()
        {
            var date_Start = DateTime.Parse("2022-11-30");
            var date_End = date_Start.AddDays(1);

            var objReportList = _db.Global03AvgHourPowers
                .Where(s => s.Time >= date_Start && s.Time < date_End)
                .OrderBy(s => s.Time)
                .ToList();

            // 最新資料 
            ViewBag.TopData = _db.Global03AvgHourPowers
                .OrderByDescending(s => s.Time)
                .Select(g => new Global
                {
                    Time = g.Time,
                    Ch1Chwflow = Math.Round(g.Ch1Chwflow, 2),
                    Ch1Chwtout = Math.Round(g.Ch1Chwtout, 2),
                    Ch1Chwtin = Math.Round(g.Ch1Chwtin, 2),
                    Ch2Chwflow = Math.Round(g.Ch2Chwflow, 2),
                    Ch2Chwtout = Math.Round(g.Ch2Chwtout, 2),
                    Ch2Chwtin = Math.Round(g.Ch2Chwtin, 2),
                    Ch1Cwflow = Math.Round(g.Ch1Cwflow, 2),
                    Ch1Cwtout = Math.Round(g.Ch1Cwtout, 2),
                    Ch1Cwtin = Math.Round(g.Ch1Cwtin, 2),
                    Ch2Cwtout = Math.Round(g.Ch2Cwtout, 2),
                    Ch2Cwtin = Math.Round(g.Ch2Cwtin, 2),
                    Ch1Kw = Math.Round(g.Power1, 2),
                    Ch2Kw = Math.Round(g.Power2, 2),
                    Ch1Dbt = Math.Round(g.Ch1Dbt, 2),
                    Ch1Rh = Math.Round(g.Ch1Rh, 2)
                })
                .FirstOrDefault();
            return View(objReportList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}