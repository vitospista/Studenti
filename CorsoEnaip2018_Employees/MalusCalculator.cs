using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Employees
{
    public abstract class MalusCalculator
    {
        public abstract decimal CalculateMalus(decimal salary);
    }

    public class LegalRefundCalculator : MalusCalculator
    {
        public override decimal CalculateMalus(decimal salary)
        {
            return salary * (decimal)0.2;
        }
    }

    public class NullMalusCalculator : MalusCalculator
    {
        // SINGLETON start
        static NullMalusCalculator()
        {
            Instance = new NullMalusCalculator();
        }

        public static NullMalusCalculator Instance { get; }

        private NullMalusCalculator()
        { }
        // SINGLETON end

        public override decimal CalculateMalus(decimal salary)
        {
            return 0;
        }
    }
}
