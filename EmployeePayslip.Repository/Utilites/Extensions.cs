using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayslip.Repository.Utilites
{
    public static class Extensions
    {
        public static decimal ConvertToCents(this decimal rate)
        {
            return rate / 100;
        }
    }
}

