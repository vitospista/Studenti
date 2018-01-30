using System;
using System.Collections.Generic;

namespace CorsoEnaip2018_NewsFeed
{
    class Program
    {
        // Design Pattern Publisher - Subscriber

        /*
             * Ho più Server che pubblicano notizie.
             * Ho una lista di Computer che possono ascoltare l'arrivo delle notizie
             * dai diversi Server.
             * Un Computer può essere sottoscritto al Server
             * e poi essere disiscritto.
             * 
             * Il Server deve implementare un'interfaccia IPublisher,
             *    che ha un metodo "void Publish(string news)"
             *    e un metodo "void AddSubscriber(ISubscriber subscriber)",
             *    e un metodo "void RemoveSubscriber(ISubscriber subscriber)"
             * In questo metodo il Server passa a tutti i suoi Subscribers la notizia.
             * Il Computer deve implementare un'interfaccia ISubscriber,
             *     con un metodo "void Receive(string server, string news)"
             *     e un metodo "void Subscribe(IPublisher publisher)"
             *     e un metodo "void Unsubscribe(IPublisher publisher)".
             * Quando un Computer riceve una notizia, stampa in Console:
             *     "Computer X ha ricevuto notiza N da Server S"             * 
             * 
             * 
             * c1 s1 c2 s2
             * c1.Subscribe(s1);
             * s1.Publish("3a Guerra Mondiale!");
             * 
             * "c1 ha ricevuto notizia da s1: "3a Guerra Mondiale""
             * 
             * c2.Subscribe(s1);
             * s1.Publish("3a Guerra Mondiale finita!")
             * "c1 ha ricevuto notizia da s1: "3a Guerra Mondiale""
             * "c2 ha ricevuto notizia da s1: "3a Guerra Mondiale""
             * 
             */
        static void Main(string[] args)
        {
            var c1 = new Computer("c1");
            var c2 = new Computer("c2");

            var s1 = new Server("s1");
            var s2 = new Server("s2");

            Console.WriteLine("Chiamo s1 senza subscribers:");
            s1.Publish("news1");

            Console.WriteLine("Sottoscrivo c1 a s1");
            c1.Subscribe(s1);
            s1.Publish("news2");

            Console.WriteLine("Disiscrivo c1 a s1");
            c1.Unsubscribe(s1);
            s1.Publish("news3");

            Console.WriteLine("Sottoscrivo c1 a s1 e s2");
            c1.Subscribe(s1);
            c1.Subscribe(s2);
            s1.Publish("news4");
            s2.Publish("news5");

            Console.WriteLine("Sottoscrivo c2 a s1 e s2");
            c2.Subscribe(s1);
            c2.Subscribe(s2);
            s1.Publish("news6");
            s2.Publish("news7");

            Console.WriteLine("Disiscrivo c1 da s2");
            c1.Unsubscribe(s2);
            s1.Publish("news8");
            s2.Publish("news9");

            Console.Read();
        }
    }

    interface IPublisher
    {
        void AddSubscriber(ISubscriber subscriber);
        void RemoveSubscriber(ISubscriber subscriber);
        void Publish(string news);
    }

    interface ISubscriber
    {
        void Subscribe(IPublisher publisher);
        void Unsubscribe(IPublisher publisher);
        void Receive(string server, string news);
    }

    class Server : IPublisher
    {
        private List<ISubscriber> _subscribers;

        public string Name { get; }

        public Server(string name)
        {
            Name = name;
            _subscribers = new List<ISubscriber>();
        }

        public void AddSubscriber(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void RemoveSubscriber(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public void Publish(string news)
        {
            var s1 = _subscribers[0];
            var computer = (Computer)s1;
            var name = computer.Name;

            foreach (var sub in _subscribers)
                sub.Receive(Name, news);
        }
    }

    class Computer : ISubscriber
    {
        public Computer(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void Receive(string server, string news)
        {
            Console.WriteLine($"Computer {Name} received from server {server} the news: '{news}'");
        }

        public void Subscribe(IPublisher publisher)
        {
            publisher.AddSubscriber(this);
        }

        public void Unsubscribe(IPublisher publisher)
        {
            publisher.RemoveSubscriber(this);
        }
    }
}
