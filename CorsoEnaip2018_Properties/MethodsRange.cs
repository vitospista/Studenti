using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Properties
{
    class MethodsRange
    {
        public int GetMax()
        {
            return this.max;
        }
        public void SetMax(int value)
        {
            if (value < this.min)
                throw new ArgumentException("Max cannot be less than Min");

            this.max = value;
        }
        private int max;

        public int GetMin()
        {
            return this.min;
        }
        public void SetMin(int value)
        {
            if (value > this.max)
                throw new ArgumentException("Min cannot be greater than Max");

            this.min = value;
        }
        private int min;

        public bool IsInRange(int i)
        {
            return i >= this.min && i <= this.max;
        }

        // se ho un sistema di binding (ad esempio una finestra grafica),
        // nel binding indico il nome del campo,
        // e il framework ricostruisce il nome del getter e del setter.

        // string s = "max"
        // --> string setterName =
            // "Set" + s.SubString(0, 1).ToUpper() + s.SubString(1, s.Length)
        // mr.Invoke(setterName)

        //problema: posso sbagliare i nomi del getter e/o del setter
    }
}
