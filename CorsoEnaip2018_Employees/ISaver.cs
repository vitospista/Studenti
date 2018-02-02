using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Employees
{
    public interface ISaver
    {
        void Save(Employee e, FixedPayCalculator c);
        void Save(Employee e, HourlyPayCalculator c);
        void Save(Employee e, CommissionPayCalculator c);
        void Save(Employee e, NullPayCalculator c);
    }
}
