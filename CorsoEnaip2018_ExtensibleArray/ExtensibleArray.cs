using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_ExtensibleArray
{
    /// <summary>
    /// Array per aggiungere e togliere elementi
    /// </summary>
    public class ExtensibleArray
    {
        public int[] _array;
        public int _index;

        public ExtensibleArray(int size)
        {
            //if (size <= 0)
            //    throw new ArgumentException("size cannot be 0 or negative!");

            //risolvere size iniziale a 0: modo 1
            //if (size == 0)
            //    this._array = new int[1];
            //else
            //    this._array = new int[size];

            this._array = new int[size];

            // questo non è necessario,
            // perché quando un'istanza è creata,
            // tutti i campi vengono inizializzati
            // con i loro valori di default
            this._index = 0;
        }

        public void Add(int i)
        {
            if (this._array.Length <= this._index)
            {
                //risolvere size iniziale a 0: modo 2

                //int newLength = this._array.Length * 2;

                //if (newLength == 0)
                //    newLength = 1;

                //int[] newArray = new int[newLength];

                //risolvere size iniziale a 0: modo 3
                int[] newArray = new int[Math.Max(1, this._array.Length * 2)];

                for(int j = 0; j < this._array.Length; j++)
                {
                    newArray[j] = this._array[j];
                }

                this._array = newArray;
            }

            this._array[this._index++] = i;
        }

        public void Remove(int i)
        {
            /*
             * esercizio: rimuove tutte le occorrenze dell'intero i dall'array.
             * 
             * es: parto da [5 4 7 5 2], quindi
             * l'array interno è [5 4 7 5 2 0 0 0], con lunghezza 8;
             * chiamo Remove(5)
             *     1) compatto l'array interno, rimuovendo tutti i 5
             *         [4 7 2 0 0 0 0 0]
             *     2) se l'insieme di elementi che rimangono
             *         è meno della metà della lunghezza dell'array,
             *         devo creare un nuovo array grande la metà,
             *         e trasferire i valori (un po' come avevo fatto
             *         per l'Add, ma invece di creare un array doppio
             *         qui devo creare un array grande la metà.
             *        4 7 2 0
             */
            // i = 5;
            // _index = 5;
            // _array.Length = 8;
            // _array =    [5 4 7 5 2 0 0 0]
            // first step: [4 7 5 2 0 0 0 0]
            //second step: [4 7 2 0 0 0 0 0]

            // _array =    [5 5 7 5 2 0 0 0]
            // _array =    [5 7 5 2 0 0 0 0]
            // _array =    [7 5 2 0 0 0 0 0]
            // _array =    [7 2 0 0 0 0 0 0]

            // _array = [2 8 5]
            // _array = [2 8 0]

            // _array =    [5 4 7 5 7 8 6 9]
            // _index = 6

            for (int j = 0; j < this._index; j++)
            {
                while (this._array[j] == i)
                {
                    for(int jj = j + 1; jj < this._index; jj++)
                    {
                        this._array[jj - 1] = this._array[jj];
                    }

                    this._array[this._index - 1] = 0;
                    this._index--;
                }
            }

            if (this._index <= this._array.Length / 2)
            {
                int[] newArray = new int[this._index];

                for(int j = 0; j < this._index; j++)
                {
                    newArray[j] = this._array[j];
                }

                this._array = newArray;
            }

            // _array =    [5 4 7 5 2 0 0]
            // first step: [4 7 5 2 0 0 0]

            // _array =    [5 4 7 6 5 0 0]
            // first step: [4 7 6 0 0 0 0]
            // newArray:   [0 0 0]
            // newArray:   [4 7 6]
        }

        public int Count()
        {
            return this._index;
        }

        public int this[int index]
        {
            get
            {
                if (!(index < this._index))
                    throw new IndexOutOfRangeException();

                return this._array[index];

                // modi alternativi per ottenere lo STESSO comportamento

                //if (!(index < this._index))
                //    throw new IndexOutOfRangeException();
                //else
                //    return this._array[index];

                //if (!(index < this._index))
                //{
                //    throw new IndexOutOfRangeException();
                //}
                //else
                //{
                //    return this._array[index];
                //}
            }
            set
            {
                if (!(index < this._index))
                    throw new IndexOutOfRangeException();

                this._array[index] = value;
            }
        }
    }
}
