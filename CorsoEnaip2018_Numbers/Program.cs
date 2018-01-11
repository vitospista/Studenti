using System;
using System.Globalization;

namespace CorsoEnaip2018_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(FindMaxInt1());
            //Console.WriteLine(FindMaxInt2());
            //Console.WriteLine(FindMaxInt3());
            Floatings();
            //Console.WriteLine(GetMaxFloat());

            CSharpNumberLimits();

            Console.Read();
        }

        private static void CSharpNumberLimits()
        {
            // 0.1 + 0.2 != 0.3 !!!
            // per avere precisione massima vanno usati i decimal!
            double d1 = 0.1;
            double d2 = 0.2;
            Console.WriteLine("La somma è 0.3? " + (d1 + d2 == 0.3));
        }

        private static int FindMaxInt1()
        {
            int i = 1;

            while (i > 0)
                i = i + 1;

            int max = i - 1;

            return max;
        }

        private static int FindMaxInt2()
        {
            int i = 0;

            while (i + 1 > 0)
                i = i + 1;

            return i;
        }

        public static int FindMaxInt3()
        {
            return int.MaxValue;
        }

        public static void Floatings()
        {
            int iii = 5;

            checked
            {
                long l = 123456123123;

                //questo non si può fare
                //int i = l;

                //cast esplicito
                //senza il checked viene fuori un intero inconsistente
                //int i = (int)l;

                //Console.WriteLine(i);
            }

            int ii = 123456;

            //cast implicito
            long ll = ii;

            // con marcatore
            float f = 3.5f;

            //con cast esplicito
            float ff = (float)3.5;

            double d = f;

            double.TryParse(
                "   7,123.456  ",
                NumberStyles.AllowThousands
                    | NumberStyles.AllowDecimalPoint
                    | NumberStyles.AllowLeadingWhite
                    | NumberStyles.AllowTrailingWhite,
                CultureInfo.GetCultureInfo("en-US"),
                out d);
            Console.WriteLine(d);
        }

        private static float GetMaxFloat()
        {
            float f = 1;

            while (f > 0)
                f = f + 1000;
                //f++;

            return f - 1;
        }
    }
}
