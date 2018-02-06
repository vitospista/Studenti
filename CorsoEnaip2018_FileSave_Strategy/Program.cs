using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_SaveFile_Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Unicorn>
            {
                new Unicorn("Rambo", 50, new DateTime(2000, 10, 1), true),
                new Unicorn("Rugiadina", 10, new DateTime(2007, 12, 25), true),
                new Unicorn("Spruzzo d'arcobaleno", 25, new DateTime(2012, 7, 31), true),
            };

            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var jsonFile = Path.Combine(desktop, "unicorns - json.txt");
            var queryStringFile = Path.Combine(desktop, "unicorns - query-string.txt");

            var saver = new Saver();
            saver.Formatter = new JsonFormatter();
            saver.SaveOnFile(list, jsonFile);

            saver.Formatter = new QueryStringFormatter();
            saver.SaveOnFile(list, queryStringFile);

            Console.Write("Unicorns successfully saved on file! Mission complete!");

            Console.Read();

            /*
             * WordDocument
             *     LanguageChecker LanguageChecker { get; set; }
             *     Visualization Visualization { get; }
             *     Theme Theme { get; }
             * 
             * 
             * 
             */
        }
    }

    class Unicorn
    {
        public Unicorn() { }

        public Unicorn(string name, int cornCentimeters, DateTime birth, bool isWild)
        {
            Name = name;
            CornCentimeters = cornCentimeters;
            Birth = birth;
            IsWild = isWild;
        }

        public string Name { get; set; }
        public int CornCentimeters { get; set; }
        public DateTime Birth { get; set; }
        public bool IsWild { get; set; }
    }

    class Saver
    {
        public Formatter Formatter
        {
            get { return formatter; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("formatter");

                formatter = value;
            }
        }
        private Formatter formatter;

        public void SaveOnFile(List<Unicorn> list, string path)
        {
            var rows = list.Select(Formatter.Format).ToArray();

            File.WriteAllLines(path, rows);
        }
    }

    abstract class Formatter
    {
        public abstract string Format(Unicorn u);
    }

    class JsonFormatter : Formatter
    {
        public override string Format(Unicorn u)
        {
            var output =
                $"{{ 'Name': '{u.Name}', " +
                $"'CornCentimeters': {u.CornCentimeters}, " +
                $"'Birth': {u.Birth.ToString("yyyy-MM-dd")}, " +
                $"'IsWild': {u.IsWild} }}";

            return output;
        }
    }

    class QueryStringFormatter : Formatter
    {
        public override string Format(Unicorn u)
        {
            var output =
                $"Name={u.Name};" +
                $"CornCentimeters={u.CornCentimeters};" +
                $"Birth={u.Birth.ToString("yyyy-MM-dd")};" +
                $"IsWild={u.IsWild}";

            return output;
        }
    }
}
