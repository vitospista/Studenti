using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Properties
{
    class FieldsRange
    {
        public int Max;
        public int Min;

        public bool IsInRange(int i)
        {
            return i >= this.Min && i <= this.Max;
        }
    }
}
