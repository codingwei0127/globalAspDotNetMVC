using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using Global608.Models;

namespace Global608.Controllers
{
    public class ExcelController : Controller
    {

        private readonly Ftis2023Context _db;
        public ExcelController(Ftis2023Context db) { _db = db; }

        // 範圍查詢
        [HttpPost]
        public IActionResult Excel_QueryDate_Download(string StartDate, string EndDate)
        {
            var date_Start = DateTime.Parse(StartDate);
            var date_End = DateTime.Parse(EndDate);

            var ExcelDataArray =
                _db.Global03AvgHourPowers.Where(s =>
                s.Time >= date_Start &&
                s.Time < date_End)
                .OrderBy(s => s.Time)
                .ToList();

            // 建立 Excel 檔案物件
            XSSFWorkbook workbook = new XSSFWorkbook();

            // 建立工作表物件
            ISheet sheet = workbook.CreateSheet("新店案場資料");

            // 定義時間格式
            ICellStyle cellStyle = workbook.CreateCellStyle();
            IDataFormat dataFormat = workbook.CreateDataFormat();
            cellStyle.DataFormat = dataFormat.GetFormat("yyyy/MM/dd HH:mm:ss");

            // 在工作表中插入標題行
            IRow headerRow = sheet.CreateRow(0);
            headerRow.CreateCell(0).SetCellValue("資料時間");
            headerRow.CreateCell(1).SetCellValue("冰水主機1號:冰水流量(LPM)");
            headerRow.CreateCell(2).SetCellValue("冰水主機1號:冰水出水溫度(°C)");
            headerRow.CreateCell(3).SetCellValue("冰水主機1號:冰水回水溫度(°C)");
            headerRow.CreateCell(4).SetCellValue("冰水主機2號:冰水流量(LPM)");
            headerRow.CreateCell(5).SetCellValue("冰水主機2號:冰水出水溫度(°C)");
            headerRow.CreateCell(6).SetCellValue("冰水主機2號:冰水回水溫度(°C)");
            headerRow.CreateCell(7).SetCellValue("冰水主機1號:冷卻水流量(共管)(LPM)");
            headerRow.CreateCell(8).SetCellValue("冰水主機1號:冷卻水出水溫度(°C)");
            headerRow.CreateCell(9).SetCellValue("冰水主機1號:冷卻水回水溫度(°C)");
            headerRow.CreateCell(10).SetCellValue("冰水主機2號:冷卻水出水溫度(°C)");
            headerRow.CreateCell(11).SetCellValue("冰水主機2號:冷卻水回水溫度(°C)");
            headerRow.CreateCell(12).SetCellValue("空調系統kw-1(kW)");
            headerRow.CreateCell(13).SetCellValue("空調系統kw-2(kW)");
            headerRow.CreateCell(14).SetCellValue("室外空氣:乾球溫度(°C)");
            headerRow.CreateCell(15).SetCellValue("室外空氣:相對溼度(%)");
           
            // 並將資料寫入工作表中
            for (int i = 0; i < ExcelDataArray.Count; i++)
            {
                // 建立一個新的工作表列
                IRow dataRow = sheet.CreateRow(i + 1);
                // 將溫度和濕度資料填入工作表中

                // 並將指定的時間格式應用到第一個儲存格中
                ICell cell = dataRow.CreateCell(0);
                cell.SetCellValue(ExcelDataArray[i].Time);
                cell.CellStyle = cellStyle;
                dataRow.CreateCell(1).SetCellValue(ExcelDataArray[i].Ch1Chwflow);
                dataRow.CreateCell(2).SetCellValue(ExcelDataArray[i].Ch1Chwtout);
                dataRow.CreateCell(3).SetCellValue(ExcelDataArray[i].Ch1Chwtin);
                dataRow.CreateCell(4).SetCellValue(ExcelDataArray[i].Ch2Chwflow);
                dataRow.CreateCell(5).SetCellValue(ExcelDataArray[i].Ch2Chwtout);
                dataRow.CreateCell(6).SetCellValue(ExcelDataArray[i].Ch2Chwtin);
                dataRow.CreateCell(7).SetCellValue(ExcelDataArray[i].Ch1Cwflow);
                dataRow.CreateCell(8).SetCellValue(ExcelDataArray[i].Ch1Cwtout);
                dataRow.CreateCell(9).SetCellValue(ExcelDataArray[i].Ch1Cwtin);
                dataRow.CreateCell(10).SetCellValue(ExcelDataArray[i].Ch2Cwtout);
                dataRow.CreateCell(11).SetCellValue(ExcelDataArray[i].Ch2Cwtin);
                dataRow.CreateCell(12).SetCellValue(ExcelDataArray[i].Power1);
                dataRow.CreateCell(13).SetCellValue(ExcelDataArray[i].Power2);
                dataRow.CreateCell(14).SetCellValue(ExcelDataArray[i].Ch1Dbt);
                dataRow.CreateCell(15).SetCellValue(ExcelDataArray[i].Ch1Rh);
            }

            // 建立一個輸出流物件來儲存 Excel 檔案
            using (MemoryStream stream = new MemoryStream())
            {
                workbook.Write(stream);
                workbook.Close();

                // 將 Excel 檔案內容轉換為字元陣列
                // 以便之後可以下載在本機
                byte[] data = stream.ToArray();
                return File(data, "application/octet-stream", "歷史數據.xlsx");
            }
        }

        // 週期查詢
        [HttpPost]
        public IActionResult Excel_QueryPeriod_Year(int Year)
        {
            var date_Start = new DateTime(Year, 1, 1);
            var date_End = new DateTime(Year, 12, 31);

            var ExcelDataArray =
                _db.Global03AvgHourPowers.Where(s =>
                s.Time >= date_Start &&
                s.Time < date_End)
                .OrderBy(s => s.Time)
                .ToList();

            // 建立 Excel 檔案物件
            XSSFWorkbook workbook = new XSSFWorkbook();

            // 建立工作表物件
            ISheet sheet = workbook.CreateSheet("新店案場資料");
            // 定義時間格式
            ICellStyle cellStyle = workbook.CreateCellStyle();
            IDataFormat dataFormat = workbook.CreateDataFormat();
            cellStyle.DataFormat = dataFormat.GetFormat("yyyy/MM/dd HH:mm:ss");

            // 在工作表中插入標題行
            IRow headerRow = sheet.CreateRow(0);
            headerRow.CreateCell(0).SetCellValue("資料時間");
            headerRow.CreateCell(1).SetCellValue("冰水主機1號:冰水流量(LPM)");
            headerRow.CreateCell(2).SetCellValue("冰水主機1號:冰水出水溫度(°C)");
            headerRow.CreateCell(3).SetCellValue("冰水主機1號:冰水回水溫度(°C)");
            headerRow.CreateCell(4).SetCellValue("冰水主機2號:冰水流量(LPM)");
            headerRow.CreateCell(5).SetCellValue("冰水主機2號:冰水出水溫度(°C)");
            headerRow.CreateCell(6).SetCellValue("冰水主機2號:冰水回水溫度(°C)");
            headerRow.CreateCell(7).SetCellValue("冰水主機1號:冷卻水流量(共管)(LPM)");
            headerRow.CreateCell(8).SetCellValue("冰水主機1號:冷卻水出水溫度(°C)");
            headerRow.CreateCell(9).SetCellValue("冰水主機1號:冷卻水回水溫度(°C)");
            headerRow.CreateCell(10).SetCellValue("冰水主機2號:冷卻水出水溫度(°C)");
            headerRow.CreateCell(11).SetCellValue("冰水主機2號:冷卻水回水溫度(°C)");
            headerRow.CreateCell(12).SetCellValue("空調系統kw-1(kW)");
            headerRow.CreateCell(13).SetCellValue("空調系統kw-2(kW)");
            headerRow.CreateCell(14).SetCellValue("室外空氣:乾球溫度(°C)");
            headerRow.CreateCell(15).SetCellValue("室外空氣:相對溼度(%)");

            // 從陣列中取出每一個溫度和濕度資料物件
            // 並將資料寫入工作表中
            for (int i = 0; i < ExcelDataArray.Count; i++)
            {
                // 建立一個新的工作表列
                IRow dataRow = sheet.CreateRow(i + 1);
                // 將溫度和濕度資料填入工作表中

                // 並將指定的時間格式應用到第一個儲存格中
                ICell cell = dataRow.CreateCell(0);
                cell.SetCellValue(ExcelDataArray[i].Time);
                cell.CellStyle = cellStyle;
                dataRow.CreateCell(1).SetCellValue(ExcelDataArray[i].Ch1Chwflow);
                dataRow.CreateCell(2).SetCellValue(ExcelDataArray[i].Ch1Chwtout);
                dataRow.CreateCell(3).SetCellValue(ExcelDataArray[i].Ch1Chwtin);
                dataRow.CreateCell(4).SetCellValue(ExcelDataArray[i].Ch2Chwflow);
                dataRow.CreateCell(5).SetCellValue(ExcelDataArray[i].Ch2Chwtout);
                dataRow.CreateCell(6).SetCellValue(ExcelDataArray[i].Ch2Chwtin);
                dataRow.CreateCell(7).SetCellValue(ExcelDataArray[i].Ch1Cwflow);
                dataRow.CreateCell(8).SetCellValue(ExcelDataArray[i].Ch1Cwtout);
                dataRow.CreateCell(9).SetCellValue(ExcelDataArray[i].Ch1Cwtin);
                dataRow.CreateCell(10).SetCellValue(ExcelDataArray[i].Ch2Cwtout);
                dataRow.CreateCell(11).SetCellValue(ExcelDataArray[i].Ch2Cwtin);
                dataRow.CreateCell(12).SetCellValue(ExcelDataArray[i].Power1);
                dataRow.CreateCell(13).SetCellValue(ExcelDataArray[i].Power2);
                dataRow.CreateCell(14).SetCellValue(ExcelDataArray[i].Ch1Dbt);
                dataRow.CreateCell(15).SetCellValue(ExcelDataArray[i].Ch1Rh);
            }

            // 建立一個輸出流物件來儲存 Excel 檔案
            using (MemoryStream stream = new MemoryStream())
            {
                workbook.Write(stream);
                workbook.Close();

                // 將 Excel 檔案內容轉換為字元陣列
                // 以便之後可以下載在本機
                byte[] data = stream.ToArray();
                return File(data, "application/octet-stream", "歷史數據.xlsx");
            }
        }

        [HttpPost]
        public IActionResult Excel_QueryPeriod_Month(string month)
        {          // 存取月份, 捨去年分
            int Month = int.Parse(month.Substring(5, 2));
            var date_Start = new DateTime(2022, Month, 1);
            var date_End = new DateTime(2022, Month, DateTime.DaysInMonth(2022, Month));

            var ExcelDataArray =
                _db.Global03AvgHourPowers.Where(s =>
                s.Time >= date_Start &&
                s.Time < date_End)
                .OrderBy(s => s.Time)
                .ToList();

            // 建立 Excel 檔案物件 
            XSSFWorkbook workbook = new XSSFWorkbook();

            // 建立工作表物件
            ISheet sheet = workbook.CreateSheet("新店案場資料");
            // 定義時間格式
            ICellStyle cellStyle = workbook.CreateCellStyle();
            IDataFormat dataFormat = workbook.CreateDataFormat();
            cellStyle.DataFormat = dataFormat.GetFormat("yyyy/MM/dd HH:mm:ss");

            // 在工作表中插入標題行
            IRow headerRow = sheet.CreateRow(0);
            headerRow.CreateCell(0).SetCellValue("資料時間");
            headerRow.CreateCell(1).SetCellValue("冰水主機1號:冰水流量(LPM)");
            headerRow.CreateCell(2).SetCellValue("冰水主機1號:冰水出水溫度(°C)");
            headerRow.CreateCell(3).SetCellValue("冰水主機1號:冰水回水溫度(°C)");
            headerRow.CreateCell(4).SetCellValue("冰水主機2號:冰水流量(LPM)");
            headerRow.CreateCell(5).SetCellValue("冰水主機2號:冰水出水溫度(°C)");
            headerRow.CreateCell(6).SetCellValue("冰水主機2號:冰水回水溫度(°C)");
            headerRow.CreateCell(7).SetCellValue("冰水主機1號:冷卻水流量(共管)(LPM)");
            headerRow.CreateCell(8).SetCellValue("冰水主機1號:冷卻水出水溫度(°C)");
            headerRow.CreateCell(9).SetCellValue("冰水主機1號:冷卻水回水溫度(°C)");
            headerRow.CreateCell(10).SetCellValue("冰水主機2號:冷卻水出水溫度(°C)");
            headerRow.CreateCell(11).SetCellValue("冰水主機2號:冷卻水回水溫度(°C)");
            headerRow.CreateCell(12).SetCellValue("空調系統kw-1(kW)");
            headerRow.CreateCell(13).SetCellValue("空調系統kw-2(kW)");
            headerRow.CreateCell(14).SetCellValue("室外空氣:乾球溫度(°C)");
            headerRow.CreateCell(15).SetCellValue("室外空氣:相對溼度(%)");

            // 從陣列中取出每一個溫度和濕度資料物件
            // 並將資料寫入工作表中
            for (int i = 0; i < ExcelDataArray.Count; i++)
            {
                // 建立一個新的工作表列
                IRow dataRow = sheet.CreateRow(i + 1);
                // 將溫度和濕度資料填入工作表中

                // 並將指定的時間格式應用到第一個儲存格中
                ICell cell = dataRow.CreateCell(0);
                cell.SetCellValue(ExcelDataArray[i].Time);
                cell.CellStyle = cellStyle;
                dataRow.CreateCell(1).SetCellValue(ExcelDataArray[i].Ch1Chwflow);
                dataRow.CreateCell(2).SetCellValue(ExcelDataArray[i].Ch1Chwtout);
                dataRow.CreateCell(3).SetCellValue(ExcelDataArray[i].Ch1Chwtin);
                dataRow.CreateCell(4).SetCellValue(ExcelDataArray[i].Ch2Chwflow);
                dataRow.CreateCell(5).SetCellValue(ExcelDataArray[i].Ch2Chwtout);
                dataRow.CreateCell(6).SetCellValue(ExcelDataArray[i].Ch2Chwtin);
                dataRow.CreateCell(7).SetCellValue(ExcelDataArray[i].Ch1Cwflow);
                dataRow.CreateCell(8).SetCellValue(ExcelDataArray[i].Ch1Cwtout);
                dataRow.CreateCell(9).SetCellValue(ExcelDataArray[i].Ch1Cwtin);
                dataRow.CreateCell(10).SetCellValue(ExcelDataArray[i].Ch2Cwtout);
                dataRow.CreateCell(11).SetCellValue(ExcelDataArray[i].Ch2Cwtin);
                dataRow.CreateCell(12).SetCellValue(ExcelDataArray[i].Power1);
                dataRow.CreateCell(13).SetCellValue(ExcelDataArray[i].Power2);
                dataRow.CreateCell(14).SetCellValue(ExcelDataArray[i].Ch1Dbt);
                dataRow.CreateCell(15).SetCellValue(ExcelDataArray[i].Ch1Rh);
            }
            // 建立一個輸出流物件來儲存 Excel 檔案
            using (MemoryStream stream = new MemoryStream())
            {
                workbook.Write(stream);
                workbook.Close();

                // 將 Excel 檔案內容轉換為字元陣列
                // 以便之後可以下載在本機
                byte[] data = stream.ToArray();
                return File(data, "application/octet-stream", "歷史數據.xlsx");

            }
        }

        [HttpPost]
        public IActionResult Excel_QueryPeriod_Day(string date)
        {
            // 將字串轉換為日期
            var dateValue = DateTime.Parse(date);

            var dateStart = dateValue.Date; // 取得該日期的當天 00:00:00
            var dateEnd = dateStart.AddDays(1); // 取得該日期當天的下一天 00:00:00

            var ExcelDataArray =
                _db.Global03AvgHourPowers.Where(s =>
                s.Time >= dateStart &&
                s.Time < dateEnd)
                .OrderBy(s => s.Time)
                .ToList();

            // 建立 Excel 檔案物件 
            XSSFWorkbook workbook = new XSSFWorkbook();

            // 建立工作表物件
            ISheet sheet = workbook.CreateSheet("新店案場資料");
            // 定義時間格式
            ICellStyle cellStyle = workbook.CreateCellStyle();
            IDataFormat dataFormat = workbook.CreateDataFormat();
            cellStyle.DataFormat = dataFormat.GetFormat("yyyy/MM/dd HH:mm:ss");

            // 在工作表中插入標題行
            IRow headerRow = sheet.CreateRow(0);
            headerRow.CreateCell(0).SetCellValue("資料時間");
            headerRow.CreateCell(1).SetCellValue("冰水主機1號:冰水流量(LPM)");
            headerRow.CreateCell(2).SetCellValue("冰水主機1號:冰水出水溫度(°C)");
            headerRow.CreateCell(3).SetCellValue("冰水主機1號:冰水回水溫度(°C)");
            headerRow.CreateCell(4).SetCellValue("冰水主機2號:冰水流量(LPM)");
            headerRow.CreateCell(5).SetCellValue("冰水主機2號:冰水出水溫度(°C)");
            headerRow.CreateCell(6).SetCellValue("冰水主機2號:冰水回水溫度(°C)");
            headerRow.CreateCell(7).SetCellValue("冰水主機1號:冷卻水流量(共管)(LPM)");
            headerRow.CreateCell(8).SetCellValue("冰水主機1號:冷卻水出水溫度(°C)");
            headerRow.CreateCell(9).SetCellValue("冰水主機1號:冷卻水回水溫度(°C)");
            headerRow.CreateCell(10).SetCellValue("冰水主機2號:冷卻水出水溫度(°C)");
            headerRow.CreateCell(11).SetCellValue("冰水主機2號:冷卻水回水溫度(°C)");
            headerRow.CreateCell(12).SetCellValue("空調系統kw-1(kW)");
            headerRow.CreateCell(13).SetCellValue("空調系統kw-2(kW)");
            headerRow.CreateCell(14).SetCellValue("室外空氣:乾球溫度(°C)");
            headerRow.CreateCell(15).SetCellValue("室外空氣:相對溼度(%)");

            // 從陣列中取出每一個溫度和濕度資料物件
            // 並將資料寫入工作表中
            for (int i = 0; i < ExcelDataArray.Count; i++)
            {
                // 建立一個新的工作表列
                IRow dataRow = sheet.CreateRow(i + 1);
                // 將溫度和濕度資料填入工作表中

                // 並將指定的時間格式應用到第一個儲存格中
                ICell cell = dataRow.CreateCell(0);
                cell.SetCellValue(ExcelDataArray[i].Time);
                cell.CellStyle = cellStyle;
                dataRow.CreateCell(1).SetCellValue(ExcelDataArray[i].Ch1Chwflow);
                dataRow.CreateCell(2).SetCellValue(ExcelDataArray[i].Ch1Chwtout);
                dataRow.CreateCell(3).SetCellValue(ExcelDataArray[i].Ch1Chwtin);
                dataRow.CreateCell(4).SetCellValue(ExcelDataArray[i].Ch2Chwflow);
                dataRow.CreateCell(5).SetCellValue(ExcelDataArray[i].Ch2Chwtout);
                dataRow.CreateCell(6).SetCellValue(ExcelDataArray[i].Ch2Chwtin);
                dataRow.CreateCell(7).SetCellValue(ExcelDataArray[i].Ch1Cwflow);
                dataRow.CreateCell(8).SetCellValue(ExcelDataArray[i].Ch1Cwtout);
                dataRow.CreateCell(9).SetCellValue(ExcelDataArray[i].Ch1Cwtin);
                dataRow.CreateCell(10).SetCellValue(ExcelDataArray[i].Ch2Cwtout);
                dataRow.CreateCell(11).SetCellValue(ExcelDataArray[i].Ch2Cwtin);
                dataRow.CreateCell(12).SetCellValue(ExcelDataArray[i].Power1);
                dataRow.CreateCell(13).SetCellValue(ExcelDataArray[i].Power2);
                dataRow.CreateCell(14).SetCellValue(ExcelDataArray[i].Ch1Dbt);
                dataRow.CreateCell(15).SetCellValue(ExcelDataArray[i].Ch1Rh);
            }
            // 建立一個輸出流物件來儲存 Excel 檔案
            using (MemoryStream stream = new MemoryStream())
            {
                workbook.Write(stream);
                workbook.Close();

                // 將 Excel 檔案內容轉換為字元陣列
                // 以便之後可以下載在本機
                byte[] data = stream.ToArray();
                return File(data, "application/octet-stream", "歷史數據.xlsx");
            }
        }
    }
}
