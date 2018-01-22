using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Shapes
{
    class Program
    {
    /*
     * Esercizio:
     * 
     * -) costruire una classe base astratta Shape con i metodi astratti
     *     -) void Draw (stampa in console qualcosa)
     *     -) double CalculateArea()
     *     -) double CalculatePerimeter()
     *     
     * -) costruire delle classi derivate:
     *      -) Rectangle
     *      -) Circle
     *      -) Line
     *    per ogni classe derivata, aggiungere le opportune proprietà in più.
     *    per ogni classe, fare l'override dei metodi di Shape.
     * 
     * -) Creare una lista di Shape, e chiamare a turno
     *    Draw, CalculateArea, ... iterando sulla lista.
     * 
     */
        static void Main(string[] args)
        {
            var list = new List<Shape>();

            var s = new Segment { Length = 4.5 };
            list.Add(s);

            // posso aggiungere un oggetto di una classe più specifica
            // in una lista di oggetti più generali
            // perché C# fa un CAST IMPLICITO:
            // list.Add((Shape)s);
            var r = new Rectangle { Height = 10, Width = 20 };
            list.Add(r);

            // la classe Shape è abstract, non posso
            // crearne istanze dirette!
            //list.Add(new Shape());

            foreach(var shape in list)
            {
                shape.Draw();
                Console.WriteLine($"Area: {shape.CalculateArea()}; Perimeter: {shape.CalculatePerimeter()}");
            }

            /*
             * Se non avessi l'override, dovrei fare ogni volta
             * una serie di if-else per capire il tipo specifico.
             * Così:
             * 
            if (shape is Segment)
            {
                var segment = (Segment)shape;
                segment.Draw();
            }
            else if (shape is Rectangle)
            {
                var rectangle = (Rectangle)shape;
                rectangle.Draw();
            }
             */

            var sq = new Square();
            sq.Width = 30;
            sq.Height = 30;

            Console.Read();
        }
    }

    abstract class Shape
    {
        // se la classe è astratta,
        // posso dichiarare qualche suo metodo o proprietà come abstract
        // e quindi non ha implementazione.
        public abstract void Draw();
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
    }

    abstract class Polygon : Shape
    {
        // se creo una classe derivata sempre abstract,
        // non sono obbligato a fare l'override dei metodi abstract.
        // invece se la classe è completa, DEVO implementarli.
    }

    class Rectangle : Shape
    {
        public virtual double Height { get; set; }
        public virtual double Width { get; set; }

        public override void Draw()
        {
            Console.WriteLine("I'm a rectangle!");
        }

        public override double CalculateArea()
        {
            return Height * Width;
        }

        public override double CalculatePerimeter()
        {
            return (Height + Width) * 2;
        }
    }

    class Square : Rectangle
    {
        // prima version di override
        private double _side;

        public override double Height
        {
            get { return _side; }
            set { _side = value; }
        }

        public override double Width
        {
            get { return _side; }
            set { _side = value; }
        }

        // seconda versione di override
        //public double Width { get; set; }

        //public double Height
        //{
        //    get { return Width; }
        //    set { Width = value; }
        //}

        public override void Draw()
        {
            Console.WriteLine("I'm a square!");
        }

        public override double CalculateArea()
        {
            return _side * _side;
        }

        public override double CalculatePerimeter()
        {
            return _side * 4;
        }
    }

    class Square2 : Shape
    {
        public double Side { get; set; }

        public override void Draw()
        {
            Console.WriteLine("I'm a square!");
        }

        public override double CalculateArea()
        {
            return Side * Side;
        }

        public override double CalculatePerimeter()
        {
            return Side * 4;
        }
    }

    class Circle : Shape
    {
        public double Radius { get; set; }

        public override void Draw()
        {
            Console.WriteLine("I'm a circle!");
        }

        public override double CalculateArea()
        {
            return Radius * Radius * Math.PI;
        }

        public override double CalculatePerimeter()
        {
            return Radius * 2 * Math.PI;
        }
    }

    class Segment : Shape
    {
        public double Length { get; set; }

        public override void Draw()
        {
            Console.WriteLine("I'm a segment!");
        }

        public override double CalculateArea()
        {
            return 0;
        }

        public override double CalculatePerimeter()
        {
            return Length;
        }
    }
}
