using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Stacks
{
    public class CountableStack<T> : ObservableStack<T>
    {
        public CountableStack(int capacity)
            : base(capacity)
        { }

        public int Count(Func<T, bool> condition)
        {
            int count = 0;

            // Se per implementare lo Stack
            // usavo internamente un array,
            // in questo metodo dovevo iterare con
            // uno dei due metodi seguenti:
            //for (int i = 0; i < _count; i++)
            //    if (condition(_elements[i]))
            //        count++;

            //foreach (var element in _elements.Take(_count))
            //    if (condition(element))
            //        count++;

            // Se uso una List<T> come storage interno
            // posso usare un semplice foreach:
            foreach (var element in _elements)
                if (condition(element))
                    count++;

            return count;
        }

        // prefer composition over inheritance:
        // meglio provare prima con la composizione di oggetti,
        // e non con l'ereditarietà, che è più rigida.

    }
}
