using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace CorsoEnaip2018_Reactive
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleObservables();
            //LinqObservables();
            //CombineLatestObservables();
            GroupByFromConsole();

            Console.Read();
        }

        private static void SimpleObservables()
        {
            var obs = new Subject<string>();
            var observer = new Observer();

            obs.OnNext("message1");

            var subscription = obs.Subscribe(observer);

            obs.OnNext("message2");

            subscription.Dispose();

            obs.OnNext("message3");

            obs.OnCompleted();
        }

        private static void LinqObservables()
        {
            var obs = new Subject<int>();
            var observer = new Observer();

            obs.OnNext(1);

            var subscription = obs
                .Where(x => x > 2)
                .Select(x => $"message{x}")
                .Subscribe(observer);

            obs.OnNext(2);
            obs.OnNext(3);
            obs.OnNext(4);
            obs.OnNext(2);

            subscription.Dispose();

            obs.OnNext(5);

            obs.OnCompleted();
        }

        private static void CombineLatestObservables()
        {
            var obs1 = new Subject<int>();
            var obs2 = new Subject<int>();

            using (var subscription = Observable
                .CombineLatest(obs1, obs2, (x, y) => x * y)
                .Select(x => x.ToString())
                .Subscribe(new Observer()))
            {
                obs1.OnNext(1);
                obs1.OnNext(2);
                obs2.OnNext(3);
                obs2.OnNext(10);
            }
                
            obs1.OnNext(4);
        }

        private static void GroupByFromConsole()
        {
            var s = new Subject<string>();

            s.GroupBy(x => x)
                .Subscribe(
                    x => Console.WriteLine($"You wrote a new group: '{x.Key}'"),
                    x => Console.WriteLine($"Error! Message: {x.Message}"),
                    () => Console.WriteLine("Sequence completed!"));

            while(true)
            {
                var read = Console.ReadLine();

                if (string.IsNullOrEmpty(read))
                {
                    s.OnCompleted();
                    break;
                }

                s.OnNext(read);
            }
        }
    }

    class Observer : IObserver<string>
    {
        public void OnCompleted()
        {
            Console.WriteLine("Finished!");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("ERRORE!");
            Console.WriteLine(error.Message);
        }

        public void OnNext(string value)
        {
            Console.WriteLine(value);
        }
    }

    //interface IObservable<T>
    //{
    //    void Subscribe(IObserver<T> observer);
    //}

    //interface IObserver<T>
    //{
    //    void OnNext(T element);
    //    void OnError(Exception ex);
    //    void OnComplete();
    //}

    // ------X-------X---------X------>
    // -----------S------------------->
}
