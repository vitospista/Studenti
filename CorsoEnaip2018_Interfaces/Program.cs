using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            // posso usare come istanza dell'interfaccia
            // qualsiasi istanza di una classe che implementa quell'interfaccia.
            // Qui le classi Giocatore e Computer implementano IGiocatore
            // quindi posso usare istanza di Giocatore e Computer,
            // senza che la classe Scacchi sappia la differenza.
            var scacchi = new Scacchi(
                new Giocatore("Mario"),
                new Computer("iMac 27 pollici"),
                new Scacchiera());
        }
    }

    class Scacchiera
    {
        public void MuoviPezzo(Casella partenza, Casella arrivo)
        {
            // controllo che la mossa sia valida
            // sposto il pezzo
            // controllo se c'è lo Scacco Matto
        }

        public bool ScaccoMatto { get; private set; }
    }

    class Casella
    {
        public Casella(int riga, char colonna)
        {
            Riga = riga;
            Colonna = colonna;
        }

        public int Riga { get; }
        public char Colonna { get; }
    }

    enum ColoreGiocatore
    {
        Bianco, Nero
    }

    class Person
    {
        public Person(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; }
    }

    class Giocatore : Person, IGiocatore
    {
        public Giocatore(string nome)
            : base(nome)
        { }

        public void GiocaMossa(Scacchiera s)
        {
            // ... studia mossa migliore e falla.
        }
    }

    class Scacchi
    {
        public IGiocatore Giocatore1 { get; }
        public IGiocatore Giocatore2 { get; }

        public IGiocatore GiocatoreCorrente { get; private set; }

        public Scacchiera Scacchiera { get; }

        public Scacchi(IGiocatore g1, IGiocatore g2, Scacchiera s)
        {
            Giocatore1 = g1;
            Giocatore2 = g2;
            Scacchiera = s;
        }

        public void Start()
        {
            while(!Scacchiera.ScaccoMatto)
            {
                GiocatoreCorrente.GiocaMossa(Scacchiera);

                CambiaGiocatore();
            }

            // quando esco dal while, g è il giocatore che ha perso.
            Console.WriteLine($"'{GiocatoreCorrente.Nome}' ha perso la partita!");
            CambiaGiocatore();
            Console.WriteLine($"'{GiocatoreCorrente.Nome}' ha vinto la partita!");
        }

        private void CambiaGiocatore()
        {
            if (GiocatoreCorrente == Giocatore1)
                GiocatoreCorrente = Giocatore2;
            else
                GiocatoreCorrente = Giocatore1;
        }
    }

    class Computer : IGiocatore
    {
        public Computer(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; }

        public void GiocaMossa(Scacchiera s)
        {
            // ...
        }
    }

    interface IGiocatore
    {
        void GiocaMossa(Scacchiera s);
        string Nome { get; }
    }
}
