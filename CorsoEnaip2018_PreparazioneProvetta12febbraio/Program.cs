using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_PreparazioneProvetta12febbraio
{
    class Program
    {
        static void Main(string[] args)
        {
            ITubeFactory factory = new BrokenTubeFactory(); // new TubeFactory();
            var lc = new LengthChecker();
            var wc = new WeightChecker();
            var f = new Filter();
            var p = new Painter();
            var a = new Approver();

            var tubes = new List<Tube>
            {
                factory.Create(5.350, 235, "Pvc"),
                factory.Create(10.2, 390, "CastIron"),
                factory.Create(3.220, 72, "Steel"),
                factory.Create(10, 470.1, "Pvc"),
                factory.Create(0.54, 23, "CastIron"),
                factory.Create(4.44, 175, "Steel"),
            };

            foreach (var t in tubes)
            {
                lc.Check(t);
                wc.Check(t);
            }

            var checkedTubes = f.RemoveRejected(tubes);

            foreach (var t in checkedTubes)
            {
                t.Accept(p);
                a.Approve(t);
            }
        }
    }

    #region Tubes
    enum TubeStatus
    {
        New,
        Checked,
        Rejected,
        Ready
    }

    abstract class Tube
    {
        public double ProjectLength { get; set; }
        public double RealLength { get; set; }
        public double ProjectWeight { get; set; }
        public double RealWeight { get; set; }
        public string Color { get; set; }
        public TubeStatus Status { get; set; }
        public abstract void Accept(IVisitor visitor);
    }

    class CastIronTube : Tube
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class PvcTube : Tube
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class SteelTube : Tube
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    #endregion

    #region Factory
    interface ITubeFactory
    {
        Tube Create(double projectLength, double projectWeight, string type);
    }

    class BrokenTubeFactory : ITubeFactory
    {
        public Tube Create(double projectLength, double projectWeight, string type)
        {
            throw new Exception();
        }
    }

    class TubeFactory : ITubeFactory
    {
        private static Random _r = new Random();

        public Tube Create(double projectLength, double projectWeight, string type)
        {
            Tube t = null;

            switch(type)
            {
                case "CastIron": t = new CastIronTube(); break;
                case "Pvc": t = new PvcTube(); break;
                case "Steel": t = new SteelTube(); break;
                default: throw new ArgumentException("Not recognized tube type!");
            }

            t.ProjectLength = projectLength;
            t.ProjectWeight = projectWeight;

            t.RealLength = t.ProjectLength * (1 + ((_r.NextDouble() - 0.5) / 25));
            t.RealWeight = t.ProjectWeight * (1 + ((_r.NextDouble() - 0.5) / 10));

            return t;
        }
    }
    #endregion

    #region Checkers
    abstract class Checker
    {
        public void Check(Tube t)
        {
            if (t.Status == TubeStatus.Rejected)
                return;

            if (!isValid(t))
                t.Status = TubeStatus.Rejected;
        }

        protected abstract bool isValid(Tube t);
    }

    class LengthChecker : Checker
    {
        protected override bool isValid(Tube t)
        {
            return Math.Abs(t.RealLength - t.ProjectLength) / 100 < 0.01;
        }
    }

    class WeightChecker : Checker
    {
        protected override bool isValid(Tube t)
        {
            return Math.Abs(t.RealWeight - t.ProjectWeight) / 100 < 0.03;
        }
    }
    #endregion

    #region Filters
    class Filter
    { 
        public List<Tube> RemoveRejected(List<Tube> input)
        {
            return input.Where(x => x.Status != TubeStatus.Rejected).ToList();
        }
    }
    #endregion

    #region Painters
    interface IVisitor
    {
        void Visit(CastIronTube tube);
        void Visit(PvcTube tube);
        void Visit(SteelTube tube);
    }

    class Painter : IVisitor
    {
        public void Visit(CastIronTube tube)
        {
            tube.Color = "Brown";
        }

        public void Visit(PvcTube tube)
        {
            tube.Color = "Orange";
        }

        public void Visit(SteelTube tube)
        {
            tube.Color = "Blue";
        }
    }
    #endregion

    #region Approvers
    class Approver
    {
        public void Approve(Tube t)
        {
            t.Status = TubeStatus.Ready;
        }
    }
    #endregion

}
