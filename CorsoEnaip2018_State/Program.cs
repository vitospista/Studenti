using System;

namespace CorsoEnaip2018_State
{
    /*
     * ParkChecker
     * all'inizio è chiuso
     * se si inserisce una moneta si apre
     * se passa un'auto si chiude
     * se si inseriscono altre monete vengono restituite
     * se si prova a chiuderlo 2 volte non succede niente
     * se prova a passare una seconda auto, non può
     * 
     * InsertCoin()
     * CarTriesToPass()
     */

    class Program
    {
        static void Main(string[] args)
        {
            var pc = new ParkChecker();
            Console.WriteLine($"Is open? {pc.IsOpen}");
            pc.CarTriesToPass();
            Console.WriteLine($"Is open? {pc.IsOpen}");
            pc.InsertCoin();
            Console.WriteLine($"Is open? {pc.IsOpen}");
            pc.CarTriesToPass();
            Console.WriteLine($"Is open? {pc.IsOpen}");
            pc.InsertCoin();
            Console.WriteLine($"Is open? {pc.IsOpen}");
            pc.InsertCoin();

            Console.Read();
        }
    }

    // implementazione procedurale
    //class ParkChecker
    //{
    //    public void InsertCoin()
    //    {
    //        if (IsOpen)
    //        {
    //            Console.WriteLine("The ParkChecker was already open! Take back the coins!");
    //        }
    //        else
    //        {
    //            IsOpen = true;
    //            Console.WriteLine("The ParkChecker has been opened!");
    //        }
    //    }

    //    public void CarTriesToPass()
    //    {
    //        if (IsOpen)
    //        {
    //            Console.WriteLine("The car has passed!");
    //            IsOpen = false;
    //            Console.WriteLine("The ParkChecker has been closed!");
    //        }
    //        else
    //        {
    //            Console.WriteLine("You shall not pass!");
    //        }
    //    }

    //    public bool IsOpen { get; private set; }
    //}

    public class ParkChecker
    {
        public ParkChecker()
        {
            CurrentState = new CloseState(this);
        }

        public State CurrentState { get; set; }

        public void InsertCoin()
        {
            CurrentState.InsertCoin();
        }

        public void CarTriesToPass()
        {
            CurrentState.CarTriesToPass();
        }

        public bool IsOpen { get { return CurrentState.IsOpen; } }
    }

    public abstract class State
    {
        protected ParkChecker _context;

        public State(ParkChecker context)
        {
            _context = context;
        }

        public abstract void InsertCoin();
        public abstract void CarTriesToPass();
        public abstract bool IsOpen { get; }
    }

    public class OpenState : State
    {
        public OpenState(ParkChecker context)
            : base(context)
        { }

        public override bool IsOpen { get { return true; } }

        public override void CarTriesToPass()
        {
            Console.WriteLine("The car has passed");
            _context.CurrentState = new CloseState(_context);
        }

        public override void InsertCoin()
        {
            Console.WriteLine("The ParkChecker is already open, take back the coins!");
        }
    }

    public class CloseState : State
    {
        public CloseState(ParkChecker context)
            : base(context)
        { }

        public override bool IsOpen { get { return false; } }

        public override void CarTriesToPass()
        {
            Console.WriteLine("The ParkChecker is closed, insert coins!");
        }

        public override void InsertCoin()
        {
            Console.WriteLine("Now the ParkChecker is open!");
            _context.CurrentState = new OpenState(_context);
        }
    }
}
