using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_NewsFeed_Events
{
    class Program
    {
        /*
         * Implementare il sistema Server-Computer con gli event.
         * Il Server avrà un metodo void Publish per pubblicare le notizie,
         * e un event Published a cui i Computer agganceranno i loro handler.
         * 
         * Prima dell'evento, creare un opportuno delegate.
         */

        static void Main(string[] args)
        {
            var c1 = new Computer { Name = "c1" };
            var c2 = new Computer { Name = "c2" };

            var s1 = new Server { Name = "s1" };
            var s2 = new Server { Name = "s2" };

            Console.WriteLine("Chiamo s1 senza subscribers:");
            s1.Publish("news1");

            Console.WriteLine("Sottoscrivo c1 a s1");
            s1.Published += c1.Receive;
            s1.Publish("news2");

            Console.WriteLine("Disiscrivo c1 a s1");
            s1.Published -= c1.Receive;
            s1.Publish("news3");

            Console.WriteLine("Sottoscrivo c1 a s1 e s2");
            s1.Published += c1.Receive;
            s2.Published += c1.Receive;
            
            s1.Publish("news4");
            s2.Publish("news5");

            Console.WriteLine("Sottoscrivo c2 a s1 e s2");
            s1.Published += c2.Receive;
            s2.Published += c2.Receive;
            s1.Publish("news6");
            s2.Publish("news7");

            Console.WriteLine("Disiscrivo c1 da s2");
            s2.Published -= c1.Receive;
            s1.Publish("news8");
            s2.Publish("news9");

            Console.Read();
        }
    }

    class Server
    {
        public event PublishHandler Published;

        public void Publish(string news)
        {
            if (Published != null)
            {
                Published.Invoke(this, news);
            }

            // In C# 6.0 posso usare l'operatore Elvis sui metodi.
            // per fare i check sui null:
            // Published?.Invoke(this, news);
        }

        public string Name { get; set; }
    }

    delegate void PublishHandler(Server s, string news);

    class Computer
    {
        public string Name { get; set; }

        public void Receive(Server s, string news)
        {
            Console.WriteLine(
                $"{Name} received from server {s.Name} the following news: '{news}'");
        }

        public void Reject(Server s, string news)
        {
            // posso agganciare anche questo metodo,
            // perché rispetta la firma del delegate PublishHandler.
        }

        public void Receive(string news)
        {
            // Questo metodo NON è agganciabile all'evento Published del server,
            // perché NON rispetta la firma del delegate:
            // manca il parametro Server.
        }
    }
}
