using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Template_Sales
{
    class Program
    {
        static void Main(string[] args)
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var filePath = Path.Combine(desktop, "test_report.xlsx");

            var fileInfo = new FileInfo(@"C:\Users\triprog-1\Desktop\test_report.xlsx");

            using (var file = new ExcelPackage(fileInfo))
            {
                using (var sheet = file.Workbook.Worksheets.Add("REPORT"))
                {
                    sheet.Cells[1, 1].Value = "Mediaworld";
                    sheet.Cells[1, 2].Value = "Mario Rossi";

                    file.Save();
                }
            }



            //var list = createSaleList();

            //var ex1 = new FlatExport();
            //ex1.Export(list);

            //var ex2 = new DateExport();
            //ex2.Export(list);

            //var ex3 = new EmployeeExport();
            //ex3.Export(list);

        }
    }

    class Sale
    {
        // ...
    }

    class FlatReport { }

    class DateReport { }

    class EmployeeReport { }
}
