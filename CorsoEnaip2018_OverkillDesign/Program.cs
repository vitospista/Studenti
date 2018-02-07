using System;

namespace CorsoEnaip2018_OverkillDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new StandardMessageFactory();
            var app = new Application(factory);

            app.Run();
        }        
    }

    interface IMessageFactory
    {
        string GenerateGreetingsString();
    }

    class StandardMessageFactory : IMessageFactory
    {
        public string GenerateGreetingsString()
        {
            return "Ciao mondo!";
        }
    }

    class Application : BaseApplication
    {
        public Application(IMessageFactory factory)
            : base(factory)
        { }

        protected override void DoStuff()
        {
            var greetingsMessage = _factory.GenerateGreetingsString();

            Console.WriteLine(greetingsMessage);
        }
    }

    abstract class BaseApplication
    {
        protected IMessageFactory _factory;

        public BaseApplication(IMessageFactory factory)
        {
            _factory = factory;
        }

        public void Run()
        {
            DoStuff();

            Console.Read();
        }

        protected abstract void DoStuff();
    }
}
