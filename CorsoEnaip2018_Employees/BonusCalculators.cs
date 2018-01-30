using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Employees
{
    public abstract class BonusCalculator
    {
        public abstract decimal CalculateBonus();
    }

    public class NoFamilyBonusCalculator : BonusCalculator
    {
        public override decimal CalculateBonus()
        {
            return 0;
        }
    }

    public class LittleFamilyBonusCalculator : BonusCalculator
    {
        public override decimal CalculateBonus()
        {
            return 200;
        }
    }

    public class BigFamilyBonusCalculator : BonusCalculator
    {
        public override decimal CalculateBonus()
        {
            return 400;
        }
    }

    public class NullBonusCalculator : BonusCalculator
    {
        static NullBonusCalculator()
        {
            Instance = new NullBonusCalculator();
        }

        public static NullBonusCalculator Instance { get; }

        private NullBonusCalculator()
        { }

        public override decimal CalculateBonus()
        {
            return 0;
        }
    }
}
