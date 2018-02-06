using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CorsoEnaip2018_FileSave_Template
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
            var jsonSaver = new JsonSaver();
            jsonSaver.SaveOnFile(list, jsonFile);

            var queryStringFile = Path.Combine(desktop, "unicorns - query-string.txt");
            var queryStringSaver = new QueryStringSaver();
            queryStringSaver.SaveOnFile(list, queryStringFile);

            Console.Write("Unicorns successfully saved on file! Mission complete!");

            Console.Read();
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

    abstract class BaseSaver
    {
        public void SaveOnFile(List<Unicorn> list, string path)
        {
            var rows = list.Select(format).ToArray();

            File.WriteAllLines(path, rows);
        }

        protected abstract string format(Unicorn u);
    }

    class JsonSaver : BaseSaver
    {
        protected override string format(Unicorn u)
        {
            var output =
                $"{{ 'Name': '{u.Name}', " +
                $"'CornCentimeters': {u.CornCentimeters}, " +
                $"'Birth': {u.Birth.ToString("yyyy-MM-dd")}, " +
                $"'IsWild': {u.IsWild} }}";

            return output;
        }
    }

    class QueryStringSaver : BaseSaver
    {
        protected override string format(Unicorn u)
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
