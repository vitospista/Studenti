using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Properties
{
    class PropertiesRange
    {
        public int Max
        {
            get
            {
                return this.max;
            }
            set
            {
                if (value < this.min)
                    throw new ArgumentException("Max cannot be less than Min");

                this.max = value;
            }
        }
        private int max;

        public int Min
        {
            get
            {
                return this.min;
            }
            set
            {
                if (value > this.max)
                    throw new ArgumentException("Min cannot be greater than Max");

                this.min = value;
            }
        }
        private int min;

        public int Name { get; set; }

        // la proprietà qui sopra è auto-implementata,
        // cioè il sistema crea dietro le quinte il codice sottostante:
        //public int Name
        //{
        //    get { return this.name; }
        //    set { this.name = value; }
        //}
        //private int name;

        public bool IsInRange(int i)
        {
            return i >= this.min && i <= this.max;
        }

        //readonly / only-get property
        public int Interval
        {
            get
            {
                return this.Max - this.Min + 1;
            }
        }

        // posso anche creare writeonly / only-set properties
        // ma è raro
    }
}
