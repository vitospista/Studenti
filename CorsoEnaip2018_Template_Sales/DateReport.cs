using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Template_Sales
{
    class DateReport : BaseReport
    {
        protected override void export(IEnumerable<Sale> sales, ExcelWorksheet sheet)
        {
            var dateGrouped = sales.GroupBy(x => x.Date);

            int row = 1;

            foreach (var g in dateGrouped)
            {
                sheet.Cells[row, 1].Value = g.Key;
                sheet.Cells[row, 1].Style.Numberformat.Format = "yyyy-mm-dd";

                row++;

                foreach (var s in g.OrderBy(x => x.ShopName))
                {
                    sheet.Cells[row, 2].Value = s.ShopName;
                    sheet.Cells[row, 3].Value = s.EmployeeName;
                    sheet.Cells[row, 4].Value = s.ProductName;
                    sheet.Cells[row, 5].Value = s.Amount;

                    row++;
                }

                row++;
            }
        }

        protected override string getFileName()
        {
            return "date_report.xlsx";
        }
    }
}
