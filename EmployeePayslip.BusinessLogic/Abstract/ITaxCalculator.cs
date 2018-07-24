using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeePayslip.BusinessLogic.Response;
using EmployeePayslip.Domain.Entity;

namespace EmployeePayslip.BusinessLogic.Abstract
{
    public interface ITaxCalculator
    {
        EmployeeResponse EmployeePaySlip(Employee employee);
    }
}
