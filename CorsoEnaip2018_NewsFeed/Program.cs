using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_NewsFeed
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Ho più Server che pubblicano notizie.
             * Ho una lista di Computer che possono ascoltare l'arrivo delle notizie
             * dai diversi Server.
             * Un Computer può essere sottoscritto al Server
             * e poi essere disiscritto.
             * 
             * Il Server deve implementare un'interfaccia IPublisher,
             *    che ha un metodo "void Publish(string news)"
             *    e un metodo "void AddSubscriber(ISubscriber subscriber)".
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
        }
    }
}
