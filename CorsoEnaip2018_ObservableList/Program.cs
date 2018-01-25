using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_ObservableList
{
    class Program
    {
        static void Main(string[] args)
        {
            var olist = new ObservableList<string>();

            olist.Added += StampaElemento;
            olist.Removed += StampaElemento;

            olist.Add("hellooo");
            olist.Add("I");
            olist.Add("am");
            olist.Add("Artificial Intelligence");
            
            olist.Remove("am");

            Console.Read();
        }

        private static void StampaElemento(object sender, RemovedEventArgs<string> e)
        {
            Console.WriteLine($"Ho rimosso: '{e.Element}'");
            Console.WriteLine($"Count is: {((ObservableList<string>)sender).Count}");
        }

        private static void StampaElemento(object sender, AddedEventArgs<string> e)
        {
            Console.WriteLine($"Ho aggiunto: '{e.Element}'");
            Console.WriteLine($"Count is: {((ObservableList<string>)sender).Count}");
        }
    }

    class ObservableList<T>
    {
        private List<T> _list;

        public event AddedEventHandler<T> Added;
        public event RemovedEventHandler<T> Removed;

        public ObservableList()
        {
            _list = new List<T>();
        }

        public void Add(T element)
        {
            _list.Add(element);
            Added.Invoke(this, new AddedEventArgs<T> { Element = element });
        }

        public void Remove(T element)
        {
            _list.Remove(element);
            Removed.Invoke(this, new RemovedEventArgs<T> { Element = element });
        }

        public T this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }

        public int Count
        {
            get { return _list.Count; }
        }
    }

    delegate void AddedEventHandler<T>(object sender, AddedEventArgs<T> e);

    class AddedEventArgs<T> : EventArgs
    {
        public T Element { get; set; }
    }

    delegate void RemovedEventHandler<T>(object sender, RemovedEventArgs<T> e);

    class RemovedEventArgs<T> : EventArgs
    {
        public T Element { get; set; }
    }
}
