using CorsoEnaip2018_Template_Sales;
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
            var list = createSaleList();

            var flatReport = new FlatReport();
            flatReport.Export(list);

            var dateReport = new DateReport();
            dateReport.Export(list);

            var employeeReport = new EmployeeReport();
            employeeReport.Export(list);

            Console.Write("Export finished! Press any key to exit...");

            Console.Read();

        }

        private static List<Sale> createSaleList()
        {
            return new List<Sale>
            {
                new Sale("Scudo templare", "Adam Kadmon", "WallMart", new DateTime(2018, 1, 2), 5),
                new Sale("Chitarra", "Bob Dylan", "Rossoni Music", new DateTime(2018, 1, 2), 3000),
                new Sale("Ascia Bipenne", "Odino Junior", "WallMart", new DateTime(2018, 1, 2), 5),
                new Sale("Corpo Alieno", "Adam Kadmon", "WallMart", new DateTime(2018, 2, 14), 750),
                new Sale("Clavicembalo", "J. S. Bach", "Rossoni Music", new DateTime(2018, 4, 16), 3000),
            };
        }
    }
}
