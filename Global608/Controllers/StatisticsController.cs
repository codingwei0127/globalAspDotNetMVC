using Global608.Models;
using Microsoft.AspNetCore.Mvc;

namespace Global608.Controllers
{
    public class StatisticsController : Controller
    {

        private readonly Ftis2023Context _db;

        public StatisticsController(Ftis2023Context db) 
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult YearQuery(int year) // 年查詢
        {
            ViewBag.year = year;

            // 整月-模式3
            ViewBag.YearData = _db.Global11AllMonthKWrts
                .Where(s => s.Time.Year == year)
                .GroupBy(s => s.Time.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    TotalRt = Math.Round(g.Average(s => s.TotalRt), 2),
                    TotalkW = Math.Round(g.Average(s => s.TotalPower), 2),
                    TotalkWrt = Math.Round(g.Average(s => s.TotalkWrt), 2)
                })
                .OrderBy(s => s.Month)
                .ToList();

            //模式1
            ViewBag.OpNo1 = _db.Global09Ch1MonthKWrts
                .Where(s => s.Time.Year == year)
                .GroupBy(s => s.Time.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    Rt1 = Math.Round(g.Average(s => s.Rt1), 2),
                    TotalkW = Math.Round(g.Average(s => s.TotalPower), 2),
                    Ch1kWrt = Math.Round(g.Average(s => s.Ch1kWrt), 2)
                })
                .OrderBy(s => s.Month)
                .ToList();

            //模式2
            ViewBag.OpNo2 = _db.Global10Ch2MonthKWrts
                .Where(s => s.Time.Year == year)
                .GroupBy(s => s.Time.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    Rt2 = Math.Round(g.Average(s => s.Rt2), 2),
                    TotalkW = Math.Round(g.Average(s => s.TotalPower), 2),
                    Ch2kWrt = Math.Round(g.Average(s => s.Ch2kWrt), 2)
                })
                .OrderBy(s => s.Month)
                .ToList();

            ViewBag.QueryType = "Year";
            return View("~/Views/Statistics/Index.cshtml");
        }

        public IActionResult BigData()
        {

            ViewBag.Global_Ch1 = _db.Global06Ch1KWrtHours
                .OrderBy(s => s.Time)
                .ToList();

            ViewBag.Global_Ch2 = _db.Global07Ch2KWrtHours
                .OrderBy(s => s.Time)
                .ToList();

            ViewBag.Global_Total = _db.Global08OpNo3Hours
                .OrderBy(s => s.Time)
                .ToList();

            return View();
        }
    }
}
