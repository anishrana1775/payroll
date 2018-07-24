using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeePayslip.BusinessLogic.Abstract;
using EmployeePayslip.BusinessLogic.Response;
using EmployeePayslip.Domain.Entity;
using EmployeePayslip.Repository.Classes;
using EmployeePayslip.Repository.Abstract;

namespace EmployeePayslip.BusinessLogic.Concrete
{
    public class TaxCalculator : ITaxCalculator
    {
        private readonly IEmployeePayslipRepository _empPaySlipRepo;

        public TaxCalculator(IEmployeePayslipRepository empPaySlipRepo)
        {
            _empPaySlipRepo = empPaySlipRepo ?? throw new NullReferenceException();
        }

        public EmployeeResponse EmployeePaySlip(Employee employee)
        {
            var grossIncome = Math.Round(CalculateGrossIncome(employee.AnnualSalary));
            var incomeTax = Math.Round(CalculateIncomeTax(employee.AnnualSalary));
            var netIncome = Math.Round(grossIncome - incomeTax);
            var superAmount = employee.SuperRate > 0 ? Math.Round(grossIncome * employee.SuperRate / 100) : 0;

            var paySlip = new EmployeeResponse
            {
                Name = $"{employee.FirstName} {employee.LastName}",
                GrossIncome =  Math.Round(grossIncome),
                IncomeTax = incomeTax,
                NetIncome = netIncome,
                SuperAmount = superAmount,
                PayPeriod = employee.PaymentStartDate
            };
            return paySlip;
        }

        private double CalculateGrossIncome(double annualSalary)
        {
            return annualSalary / 12;
        }

        private double CalculateIncomeTax(double annualSalary)
        {
            if (annualSalary > 0)
            {
                var taxSlab = _empPaySlipRepo.GetTaxSlabDetails(annualSalary);

                return Math.Abs(taxSlab.TaxChargeRate) < 0
                    ? 0
                    : (((annualSalary - taxSlab.SlabLowerLimit) * taxSlab.TaxChargeRate) / 100 +
                       taxSlab.FixedTaxPerSlab) / 12;
            }

            return 0;
        }
    }
}
