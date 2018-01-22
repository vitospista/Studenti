using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_NestedClassPlays
{
    class Program
    {
        static void Main(string[] args)
        {
            var eb = new EnaipBuilding();

            // siccome EnaipClassroom è private,
            // questa riga non compila:
            //var ecr = new EnaipBuilding.EnaipClassroom();
        }
    }

    // una classe di default è 'internal'.
    class EnaipBuilding
    {
        // tutti i membri di una classe
        // di default sono 'private'
        string Name;

        // una classe annidata (nested)
        // è 'private' di default come tutti gli altri membri.
        class EnaipClassroom
        {
            // un membro public di una classe nested
            // è visibile da tutti gli altri membri della classe contenitore
            public string Name { get; set; }

            // un membro private di una classe nested
            // NON è visibile al di fuori della classe stessa.
            private string _name;
        }

        public EnaipBuilding()
        {
            C18 = new EnaipClassroom();

            // vedo questa proprietà di EnaipClassroom perché è 'public'
            C18.Name = "Aula C18";

            // NON vedo questo campo di EnaipClassroom perché è 'private':
            //C18._name = "C18";
        }

        EnaipClassroom C18 { get; set; }

        public string C18bis { get; set; }
    }
}
