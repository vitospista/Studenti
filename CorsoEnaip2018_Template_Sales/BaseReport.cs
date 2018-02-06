using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Template_Sales
{
    abstract class BaseReport
    {
        public void Export(IEnumerable<Sale> sales)
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filePath = Path.Combine(desktop, getFileName());
            var fileInfo = new FileInfo(filePath);

            using (var file = new ExcelPackage(fileInfo))
            {
                using (var sheet = file.Workbook.Worksheets["REPORT"]
                    ?? file.Workbook.Worksheets.Add("REPORT"))
                {
                    export(sales, sheet);

                    file.Save();
                }
            }
        }

        protected abstract string getFileName();

        protected abstract void export(IEnumerable<Sale> sales, ExcelWorksheet sheet);
    }
}
