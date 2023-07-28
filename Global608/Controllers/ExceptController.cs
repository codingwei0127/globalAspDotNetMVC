using Microsoft.AspNetCore.Mvc;
using Global608.Models;

namespace Global608.Controllers
{
    public class ExceptController : Controller
    {
        private readonly Ftis2023Context _db;
        public ExceptController(Ftis2023Context db) { _db = db; }
        public IActionResult Index()
        {
            ViewBag.Number = 0;

            ViewBag.Ch1Chwflow = _db.Global03AvgHourPowers
                .Where(s => s.Ch1Chwflow > 9000 || s.Ch1Chwflow < 0)
                .OrderBy(s => s.Time)
                .ToList();

            ViewBag.Ch1Chwtout = _db.Global03AvgHourPowers
                .Where(s => s.Ch1Chwtout > 19 || s.Ch1Chwtout < 6)
                .OrderBy(s => s.Time)
                .ToList();

            ViewBag.Ch1Chwtin = _db.Global03AvgHourPowers
                .Where(s => s.Ch1Chwtin >  21 || s.Ch1Chwtin < 6)
                .OrderBy(s => s.Time)
                .ToList();

            ViewBag.Ch2Chwflow = _db.Global03AvgHourPowers
                .Where(s => s.Ch2Chwflow > 12000 || s.Ch2Chwflow < 0)
                .OrderBy(s => s.Time)
                .ToList();

            ViewBag.Ch2Chwtout = _db.Global03AvgHourPowers
                .Where(s => s.Ch2Chwtout > 22 || s.Ch2Chwtout < 6)
                .OrderBy(s => s.Time)
                .ToList();

            ViewBag.Ch2Chwtin = _db.Global03AvgHourPowers
                .Where(s => s.Ch2Chwtin > 28 || s.Ch2Chwtin < 6)
                .OrderBy(s => s.Time)
                .ToList();

            ViewBag.Ch1Cwflow = _db.Global03AvgHourPowers
                .Where(s => s.Ch1Cwflow > 15000 || s.Ch1Cwflow < 0)
                .OrderBy(s => s.Time)
                .ToList();

            ViewBag.Ch1Cwtout = _db.Global03AvgHourPowers
                .Where(s => s.Ch1Cwtout > 36.2 || s.Ch1Cwtout < 6)
                .OrderBy(s => s.Time)
                .ToList();

            ViewBag.Ch1Cwtin = _db.Global03AvgHourPowers
                .Where(s => s.Ch1Cwtin > 33 || s.Ch1Cwtin < 6)
                .OrderBy(s => s.Time)
                .ToList();

            ViewBag.Ch2Cwtout = _db.Global03AvgHourPowers
                .Where(s => s.Ch2Cwtout > 39.2 || s.Ch2Cwtout < 6)
                .OrderBy(s => s.Time)
                .ToList();

            ViewBag.Ch2Cwtin = _db.Global03AvgHourPowers
                .Where(s => s.Ch2Cwtin > 33.9 || s.Ch2Cwtin < 6)
                .OrderBy(s => s.Time)
                .ToList();

            ViewBag.Ch1Kw = _db.Global03AvgHourPowers
                .Where(s => s.Power1 > 640 || s.Power1 < 0)
                .OrderBy(s => s.Time)
                .ToList();

            ViewBag.Ch2Kw = _db.Global03AvgHourPowers
                .Where(s => s.Power2 > 525 || s.Power2 < 0)
                .OrderBy(s => s.Time)
                .ToList();

            ViewBag.Ch1Dbt = _db.Global03AvgHourPowers
                .Where(s => s.Ch1Dbt > 40 || s.Ch1Dbt < 0)
                .OrderBy(s => s.Time)
                .ToList();

            ViewBag.Ch1Rh = _db.Global03AvgHourPowers
                .Where(s => s.Ch1Rh > 99.5 || s.Ch1Rh < 6)
                .OrderBy(s => s.Time)
                .ToList();

            return View();

        }
    }
}
