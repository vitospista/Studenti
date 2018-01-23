using CorsoEnaip2018_Interfaces2Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Interfaces2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(new ConsoleListener());

            p.Name = "Mario";
            p.Surname = "Rossi";
            p.Name = "Maria";

            Console.Read();
        }
    }

    class ConsoleListener : ICompleteNameListener
    {
        public void SetNewCompleteName(string completeName)
        {
            Console.WriteLine($"Il nuovo nome completo è: {completeName}");
        }
    }
}
