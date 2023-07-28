using Microsoft.AspNetCore.Mvc;
using Global608.Models;

namespace Global608.Controllers
{
    public class QueryController : Controller
    {

        private readonly Ftis2023Context _db;
        public QueryController(Ftis2023Context db) { _db = db; }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string StartDate, string EndDate)
        {
            var date_Start = DateTime.Parse(StartDate);
            var date_End = DateTime.Parse(EndDate);

            ViewBag.Data = _db.Global03AvgHourPowers
                .Where(s => s.Time >= date_Start && s.Time < date_End)
                .OrderBy(s => s.Time)
                .ToList();

            ViewBag.StartDate = StartDate;
            ViewBag.EndDate = EndDate;

            return View();
        }

        public IActionResult QueryPeriod()
        {
            return View();
        }

        // 週期查詢
        [HttpPost]
        public IActionResult YearQuery(int year) // 年查詢
        {

            ViewBag.YearData = _db.Global03AvgHourPowers
                .Where(s => s.Time.Year == year)
                .GroupBy(s => s.Time.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    AverageCh1Chwflow = Math.Round(g.Average(s => s.Ch1Chwflow), 2),
                    AverageCh1Chwtout = Math.Round(g.Average(s => s.Ch1Chwtout), 2),
                    AverageCh1Chwtin = Math.Round(g.Average(s => s.Ch1Chwtin), 2),
                    AverageCh2Chwflow = Math.Round(g.Average(s => s.Ch2Chwflow), 2),
                    AverageCh2Chwtout = Math.Round(g.Average(s => s.Ch2Chwtout), 2),
                    AverageCh2Chwtin = Math.Round(g.Average(s => s.Ch2Chwtin), 2),
                    AverageCh1Cwflow = Math.Round(g.Average(s => s.Ch1Cwflow), 2),
                    AverageCh1Cwtout = Math.Round(g.Average(s => s.Ch1Cwtout), 2),
                    AverageCh1Cwtin = Math.Round(g.Average(s => s.Ch1Cwtin), 2),
                    AverageCh2Cwtout = Math.Round(g.Average(s => s.Ch2Cwtout), 2),
                    AverageCh2Cwtin = Math.Round(g.Average(s => s.Ch2Cwtin), 2),
                    AverageCh1Kw = Math.Round(g.Average(s => s.Power1), 2),
                    AverageCh2Kw = Math.Round(g.Average(s => s.Power2), 2),
                    AverageCh1Dbt = Math.Round(g.Average(s => s.Ch1Dbt), 2),
                    AverageCh1Rh = Math.Round(g.Average(s => s.Ch1Rh), 2)
                })
                .OrderBy(s => s.Month)
                .ToList();

            ViewBag.QueryType = "Year";
            return View("~/Views/Query/QueryPeriod.cshtml");
        }

        [HttpPost]
        public IActionResult MonthQuery(string month) // 月查詢
        {
            // 存取月份, 捨去年分
            int Month = int.Parse(month.Substring(5, 2));

            // 存取年分, 捨去月份
            int Year = int.Parse(month.Substring(0, 4));

            ViewBag.MonthData = _db.Global03AvgHourPowers
                .Where(s => s.Time.Month == Month && s.Time.Year == Year)
                .GroupBy(s => s.Time.Day)
                .Select(g => new
                {
                    Day = g.Key,
                    AverageCh1Chwflow = Math.Round(g.Average(s => s.Ch1Chwflow), 2),
                    AverageCh1Chwtout = Math.Round(g.Average(s => s.Ch1Chwtout), 2),
                    AverageCh1Chwtin = Math.Round(g.Average(s => s.Ch1Chwtin), 2),
                    AverageCh2Chwflow = Math.Round(g.Average(s => s.Ch2Chwflow), 2),
                    AverageCh2Chwtout = Math.Round(g.Average(s => s.Ch2Chwtout), 2),
                    AverageCh2Chwtin = Math.Round(g.Average(s => s.Ch2Chwtin), 2),
                    AverageCh1Cwflow = Math.Round(g.Average(s => s.Ch1Cwflow), 2),
                    AverageCh1Cwtout = Math.Round(g.Average(s => s.Ch1Cwtout), 2),
                    AverageCh1Cwtin = Math.Round(g.Average(s => s.Ch1Cwtin), 2),
                    AverageCh2Cwtout = Math.Round(g.Average(s => s.Ch2Cwtout), 2),
                    AverageCh2Cwtin = Math.Round(g.Average(s => s.Ch2Cwtin), 2),
                    AverageCh1Kw = Math.Round(g.Average(s => s.Power1), 2),
                    AverageCh2Kw = Math.Round(g.Average(s => s.Power2), 2),
                    AverageCh1Dbt = Math.Round(g.Average(s => s.Ch1Dbt), 2),
                    AverageCh1Rh = Math.Round(g.Average(s => s.Ch1Rh), 2)
                })
                .OrderBy(s => s.Day)
                .ToList();

            ViewBag.QueryType = "Month";
            return View("~/Views/Query/QueryPeriod.cshtml");
        }

        [HttpPost]
        public IActionResult DayQuery(string date)
        {
            String date_str = date;
            var DateTime_date = DateTime.Parse(date_str);
            var DateTime_date_PlusOne = DateTime_date.AddDays(1); // 加一天

            ViewBag.DayData =
                _db.Global03AvgHourPowers.Where(s =>
                s.Time >= DateTime_date &&
                s.Time < DateTime_date_PlusOne)
                .Select(s => new
                {
                    Time = s.Time,
                    Ch1Chwflow = Math.Round(s.Ch1Chwflow, 2),
                    Ch1Chwtout = Math.Round(s.Ch1Chwtout, 2),
                    Ch1Chwtin = Math.Round(s.Ch1Chwtin, 2),
                    Ch2Chwflow = Math.Round(s.Ch2Chwflow, 2),
                    Ch2Chwtout = Math.Round(s.Ch2Chwtout, 2),
                    Ch2Chwtin = Math.Round(s.Ch2Chwtin, 2),
                    Ch1Cwflow = Math.Round(s.Ch1Cwflow, 2),
                    Ch1Cwtout = Math.Round(s.Ch1Cwtout, 2),
                    Ch1Cwtin = Math.Round(s.Ch1Cwtin, 2),
                    Ch2Cwtout = Math.Round(s.Ch2Cwtout, 2),
                    Ch2Cwtin = Math.Round(s.Ch2Cwtin, 2),
                    Ch1Kw = Math.Round(s.Power1, 2),
                    Ch2Kw = Math.Round(s.Power2, 2),
                    Ch1Dbt = Math.Round(s.Ch1Dbt, 2),
                    Ch1Rh = Math.Round(s.Ch1Rh, 2)
                })
                .OrderBy(s => s.Time)
                .ToList();

            ViewBag.QueryType = "Day";
            return View("~/Views/Query/QueryPeriod.cshtml");
        }

    }
}
