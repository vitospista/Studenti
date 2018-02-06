using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Template_Sales
{
    class EmployeeReport : BaseReport
    {
        protected override void export(IEnumerable<Sale> sales, ExcelWorksheet sheet)
        {
            var employeeRows = sales
                .GroupBy(x => x.EmployeeName)
                .Select(x => new EmployeeRow
                    {
                        Name = x.Key,
                        FirstProductDate = x.Min(s => s.Date),
                        LastProductDate = x.Max(s => s.Date),
                        TotalSoldAmount = x.Sum(s => s.Amount)
                    })
                .OrderByDescending(x => x.TotalSoldAmount);

            int row = 1;

            foreach (var er in employeeRows)
            {
                sheet.Cells[row, 1].Value = er.Name;
                sheet.Cells[row, 2].Value = er.FirstProductDate;
                sheet.Cells[row, 3].Value = er.LastProductDate;
                sheet.Cells[row, 4].Value = er.TotalSoldAmount;

                row++;
            }
        }

        protected override string getFileName()
        {
            return "employee_report.xlsx";
        }

        class EmployeeRow
        {
            public string Name { get; set; }
            public DateTime FirstProductDate { get; set; }
            public DateTime LastProductDate { get; set; }
            public decimal TotalSoldAmount { get; set; }
        }
    }
}
