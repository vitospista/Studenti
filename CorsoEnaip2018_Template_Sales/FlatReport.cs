using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Template_Sales
{
    class FlatReport : BaseReport
    {
        protected override void export(IEnumerable<Sale> sales, ExcelWorksheet sheet)
        {
            int row = 1;

            foreach (var s in sales)
            {
                sheet.Cells[row, 1].Value = s.ProductName;

                sheet.Cells[row, 2].Value = s.EmployeeName;

                sheet.Cells[row, 3].Value = s.ShopName;

                sheet.Cells[row, 4].Value = s.Date;
                sheet.Cells[row, 4].Style.Numberformat.Format = "yyyy-mm-dd";

                sheet.Cells[row, 5].Value = s.Amount;

                row++;
            }
        }

        protected override string getFileName()
        {
            return "flat_report.xlsx";
        }
    }
}
