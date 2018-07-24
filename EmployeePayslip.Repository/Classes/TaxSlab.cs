using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeePayslip.Repository.Utilites;

namespace EmployeePayslip.Repository.Classes
{
    public class TaxSlab
    {
        public double SlabLowerLimit { get; set; }
        public double SlabUpperLimit { get; set; }
        public double FixedTaxPerSlab { get; set; }
        public double TaxChargeRate { get; set; }
    }
}
