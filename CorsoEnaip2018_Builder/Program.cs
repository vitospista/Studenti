using System;
using System.Diagnostics;
using System.Text;

namespace CorsoEnaip2018_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            // il builder più comune
            // da usare quando devo gestire
            // almeno centinaia di stringhe
            // da concatenare, modificare, inserire, ecc.
            var sb = new StringBuilder();
            sb.Append("Ciao");
            sb.Append(" ");
            sb.Append("mondo!");
            var finalString = sb.ToString();

            //builder senza fluent
            //var hb = new HamburgerBuilder();
            //hb.AddBread(BreadType.Normal);
            //hb.AddBurgers(2);
            //hb.AddOnion();
            //var h = hb.Build();

            //builder con fluent
            var hb = new HamburgerBuilder()
                .AddBread(BreadType.Normal)
                .AddBurgers(2)
                .AddOnion();

            var hamburgerBuiltAndCooked = hb.Build();
        }
    }

    // builder senza fluent
    class HamburgerBuilder
    {
        public HamburgerBuilder AddBurgers(int count)
        {
            return this;
        }

        public HamburgerBuilder AddCheese()
        {
            return this;
        }

        public HamburgerBuilder AddOnion()
        {
            return this;
        }

        public HamburgerBuilder AddBread(BreadType type)
        {
            return this;
        }

        public Hamburger Build()
        {
            var h = new Hamburger
            {
                // fill with the configuration
            };

            cook(h);

            return h;
        }

        private void cook(Hamburger h)
        {
            throw new NotImplementedException();
        }
    }

    public enum BreadType
    {
        Integral,
        Normal,
        Sesame
    }

    class Hamburger
    {

    }
}
