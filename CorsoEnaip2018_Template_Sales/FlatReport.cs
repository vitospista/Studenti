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
    class FlatReport
    {
        public void Export(IEnumerable<Sale> sales)
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filePath = Path.Combine(desktop, "flat_report.xlsx");
            var fileInfo = new FileInfo(filePath);

            using (var file = new ExcelPackage(fileInfo))
            {
                using (var sheet = file.Workbook.Worksheets["REPORT"]
                    ?? file.Workbook.Worksheets.Add("REPORT"))
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

                    file.Save();
                }
            }

            // se voglio avviare Excel dopo aver fatto l'export
            //Process.Start(filePath);
        }
    }
}
