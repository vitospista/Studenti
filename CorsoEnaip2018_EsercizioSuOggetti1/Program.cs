using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_EsercizioSuOggetti1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* creare una classe Employee con:
             * -) Name
             * -) Surname
             * -) Sex
             * -) Birth
             * -) Salary
             * 
             * creare una lista di Employee con alcune istanze List<Employee>
             * 
             * creare i seguenti metodi che prendono in input la lista e restituiscono:
             * -) una lista con solo i nomi (List<string>)
             * -) una lista di Employee il cui nome comincia per A
             * -) una lista di Employee di quelli nati prima del 2000
             * -) una lista di Employee di quelli che guadagnano più di 25000 € / anno
             * -) la percentuale di femmine rispetto al totale.
             */
            List<Employee> list = createList();

            List<string> names = getNameList(list);
            List<Employee> employeesWithA = filterEmployeesWithA(list);
            List<Employee> employeesPre2000 = filterEmployeesPre2000(list);
            List<Employee> employeesSuperRich = filterEmployeesSuperRich(list);
            double percentageOfFemales = calculatePercentageOfFemales(list);
        }

        private static List<string> getNameList(List<Employee> list)
        {
            List<string> names = new List<string>();

            for(int i = 0; i < list.Count; i++)
            {
                names.Add(list[i].Name);
            }

            return names;
        }

        private static List<Employee> filterEmployeesWithA(List<Employee> list)
        {
            List<Employee> filtered = new List<Employee>();

            for(int i = 0; i < list.Count; i++)
                if (list[i].Name.StartsWith("A"))
                    filtered.Add(list[i]);

            return filtered;
        }

        private static List<Employee> filterEmployeesPre2000(List<Employee> list)
        {
            List<Employee> filtered = new List<Employee>();

            for (int i = 0; i < list.Count; i++)
                if (list[i].Birth.Year < 2000)
                    filtered.Add(list[i]);

            return filtered;
        }

        private static List<Employee> filterEmployeesSuperRich(List<Employee> list)
        {
            List<Employee> filtered = new List<Employee>();

            for (int i = 0; i < list.Count; i++)
                if (list[i].Salary > 25000)
                    filtered.Add(list[i]);

            return filtered;
        }

        private static double calculatePercentageOfFemales(List<Employee> list)
        {
            int femaleCount = 0;
            
            for(int i = 0; i < list.Count; i++)
                if (list[i].Sex == SexType.Female)
                    femaleCount++;

            return (double)femaleCount / list.Count;
        }

        static List<Employee> createList()
        {
            List<Employee> list = new List<Employee>();
            //Employee e1 = new Employee();
            //e1.Name = "Mario";
            //e1.Surname = "Rossi";
            //e1.Sex = SexType.Male;
            //e1.Birth = new DateTime(1970, 3, 1);
            //e1.Salary = 15000;

            Employee e1 = new Employee()
            {
                Name = "Mario",
                Surname = "Rossi",
                Sex = SexType.Male,
                Birth = new DateTime(1970, 3, 1),
                Salary = 15000,
            };
            list.Add(e1);

            Employee e2 = new Employee()
            {
                Name = "Aldo",
                Surname = "Neri",
                Sex = SexType.Male,
                Birth = new DateTime(2000, 6, 10),
                Salary = 5000,
            };
            list.Add(e2);

            Employee e3 = new Employee()
            {
                Name = "Anna",
                Surname = "Gialli",
                Sex = SexType.Female,
                Birth = new DateTime(1999, 12, 25),
                Salary = 26000,
            };
            list.Add(e3);

            Employee e4 = new Employee()
            {
                Name = "Edoardo",
                Surname = "Blu",
                Sex = SexType.Male,
                Birth = new DateTime(2002, 9, 30),
                Salary = 35000,
            };
            list.Add(e4);

            return list;
        }
    }

    class Employee
    {
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("name");

                value = value.Substring(0, 1).ToUpper() + value.Substring(1);
            }
        }
        private string name;

        public string Surname { get; set; }
        public SexType Sex { get; set; }
        public DateTime Birth { get; set; }
        public decimal Salary { get; set; }
    }

    enum SexType
    {
        Male = 1,
        Female = 2
    }
}
