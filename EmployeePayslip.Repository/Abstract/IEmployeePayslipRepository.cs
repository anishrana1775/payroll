using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeePayslip.Repository.Classes;

namespace EmployeePayslip.Repository.Abstract
{
    public interface IEmployeePayslipRepository
    {
        TaxSlab GetTaxSlabDetails(double salary);
        double GetTaxChargeFromSlab(double salary);
    }
}
