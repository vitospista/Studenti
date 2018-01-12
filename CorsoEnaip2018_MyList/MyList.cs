using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_MyList
{
    /// <summary>
    /// Array per aggiungere e togliere elementi
    /// </summary>
    public class MyList
    {
        public int[] _array;

        public MyList(int size)
        {
            this._array = new int[size];
        }

        public void Add(int i)
        {
            throw new NotImplementedException();
        }

        public void Remove(int i)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int this[int index]
        {
            get
            {
                return this._array[index];
            }
            set
            {
                this._array[index] = value;
            }
        }
    }
}
