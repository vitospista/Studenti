
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_NamespacePlays
{
    // gli import fatti in un namespace sono visibili
    // anche dentro tutti i namespace figli.
    // quindi le classi dentro n3 vedono questo using.
    using n1;

    namespace n4
    {
        // questo using invece non è visibile in n3
        // perché n3 non è suo 'figlio';
        //using System.Collections.Generic;
    }

    namespace n3
    {
        // posso fare import di namespace dentro altri namespace
        using System.Collections.Generic;

        class Program
        {
            static void Main(string[] args)
            {
                var c1 = new C1();
                var list = new List<string>();
            }
        }
    }
}

namespace n1
{
    public class C1 { }
}

namespace n2
{
    public class C2
    {
        // C1 non lo vedo perché non c'è uno 'using n1'
        // né in questo namespace né nei suoi parent.
        // Infatti questa riga non compila:
        //public C1 C1 { get; set; }
    }
}
