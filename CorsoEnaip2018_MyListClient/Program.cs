using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorsoEnaip2018_MyList;

namespace CorsoEnaip2018_MyListClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList l = new MyList(10);

            l[4] = 12;
        }
    }
}
