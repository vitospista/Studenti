using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Func1
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

            List<Employee> employeesWithA = filterEmployeesWithA(list);

            // posso passare metodi come parametri!
            // Non eseguo il metodo sul momento, lo passo soltanto!
            // poi è filter a decidere quando e come chiamarlo
            // per ottenerne un risultato.
            List<Employee> employeesPre2000 = filter(list, isYearPre2000);
            List<Employee> employeePre1970 = filter(list, isYearPre1970);
            List<Employee> employeesSuperRich = filter(list, isSalaryMoreThan25000);

            // lambda expression
            //Func<Employee, bool> lambdaIsYearPre2000 =
            //    (Employee e) =>
            //    {
            //        return e.Birth.Year < 2000;
            //    };

            // il tipo Employee è già chiaro nella dichiarazione,
            // e quindi C# con la 'Type Inference' lo capisce da solo.
            // Quindi posso ometterlo.
            //Func<Employee, bool> lambdaIsYearPre2000 =
            //    (e) => { return e.Birth.Year < 2000; };

            // il parametro è uno solo, quindi non mi servono le ()
            //Func<Employee, bool> lambdaIsYearPre2000 =
            //    e => { return e.Birth.Year < 2000; };

            // siccome il Body è una singola istruzione semplice,
            // posso evitare le {} e il return:
            Func<Employee, bool> lambdaIsYearPre2000 =
                e => e.Birth.Year < 2000;

            employeesPre2000 = filter(list, lambdaIsYearPre2000);

            // posso scrivere la lambda direttamente come parametro di un metodo
            employeesPre2000 = filter(list, e => e.Birth.Year < 2000);
            employeePre1970 = filter(list, e => e.Birth.Year < 1970);
            employeesSuperRich = filter(list, e => e.Salary > 25000);

            // implementare i seguenti filtri:

            // lista di impiegati nati in Aprile
            // lista di impiegati maschi
            // lista di impiegati con più di un anno di servizio
            // lista di impiegati con nome che è più lungo di 4 caratteri

            // farlo sia creando metodi appositi
            // sia usando lambda expression.

            // (esecizio lasciato agli studenti)
            // (Employee e) => { return e.Name; }

            List<string> names = map(list, e => e.Name);
            List<string> surnames = map(list, e => e.Surname);
            List<decimal> salaries = map(list, e => e.Salary);

            double percentageOfFemales = calculatePercentageOfFemales(list);
        }

        private static List<Employee> filterEmployeesWithA(List<Employee> list)
        {
            List<Employee> filtered = new List<Employee>();

            for (int i = 0; i < list.Count; i++)
                if (list[i].Name.StartsWith("A"))
                    filtered.Add(list[i]);

            return filtered;
        }

        private static bool isYearPre2000(Employee e)
        {
            return e.Birth.Year < 2000;
        }

        private static bool isYearPre1970(Employee e)
        {
            return e.Birth.Year < 1970;
        }

        private static bool isSalaryMoreThan25000(Employee employee)
        {
            return employee.Salary > 25000;
        }

        private static List<Employee> filter(
            List<Employee> list,
            Func<Employee, bool> mustInclude)
        {
            List<Employee> filtered = new List<Employee>();

            for (int i = 0; i < list.Count; i++)
                if (mustInclude(list[i]))
                    filtered.Add(list[i]);

            return filtered;
        }

        private static List<T> map<T>(
            List<Employee> list,
            Func<Employee, T> projection)
        {
            List<T> projected = new List<T>();

            for (int i = 0; i < list.Count; i++)
            {
                projected.Add(projection(list[i]));
            }

            return projected;
        }

        private static double calculatePercentageOfFemales(List<Employee> list)
        {
            int femaleCount = 0;

            for (int i = 0; i < list.Count; i++)
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
                YearsOfService = 2,
            };
            list.Add(e1);

            Employee e2 = new Employee()
            {
                Name = "Aldo",
                Surname = "Neri",
                Sex = SexType.Male,
                Birth = new DateTime(2000, 6, 10),
                Salary = 5000,
                YearsOfService = 1,
            };
            list.Add(e2);

            Employee e3 = new Employee()
            {
                Name = "Anna",
                Surname = "Gialli",
                Sex = SexType.Female,
                Birth = new DateTime(1999, 12, 25),
                Salary = 26000,
                YearsOfService = 10,
            };
            list.Add(e3);

            Employee e4 = new Employee()
            {
                Name = "Edoardo",
                Surname = "Blu",
                Sex = SexType.Male,
                Birth = new DateTime(2002, 9, 30),
                Salary = 35000,
                YearsOfService = 1
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

                this.name = value;
            }
        }
        private string name;

        public string Surname { get; set; }
        public SexType Sex { get; set; }
        public DateTime Birth { get; set; }
        public decimal Salary { get; set; }
        public int YearsOfService { get; set; }
    }

    enum SexType
    {
        Male = 1,
        Female = 2
    }
}
