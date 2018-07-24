using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeePayslip.Repository.Abstract;
using EmployeePayslip.Repository.Classes;
using EmployeePayslip.Repository.Utilites;

namespace EmployeePayslip.Repository
{
    /// <summary>
    /// Tax Slab repository to get tax spab for Employee Payslip calculation
    /// </summary>
    public class EmployeePayslipRepositiry : IEmployeePayslipRepository
    {
        /// <summary>
        /// Tax Slab collection
        /// </summary>
       private readonly List<TaxSlab> _taxSlabList = new List<TaxSlab>();
        private List<TaxSlab> SetTaxSlabs()
        {
            _taxSlabList.Clear();

            _taxSlabList.Add(new TaxSlab { SlabLowerLimit = 0, SlabUpperLimit = 18200, FixedTaxPerSlab = 0, TaxChargeRate = 0});
            _taxSlabList.Add(new TaxSlab { SlabLowerLimit = 18201, SlabUpperLimit = 37000, FixedTaxPerSlab = 0, TaxChargeRate = 19 });
            _taxSlabList.Add(new TaxSlab { SlabLowerLimit = 37001.0, SlabUpperLimit = 87000.0, FixedTaxPerSlab = 3572, TaxChargeRate = 32.5 });
            _taxSlabList.Add(new TaxSlab { SlabLowerLimit = 87001.0, SlabUpperLimit = 180000.0, FixedTaxPerSlab = 19822, TaxChargeRate = 37 });
            _taxSlabList.Add(new TaxSlab { SlabLowerLimit = 180000, SlabUpperLimit = double.MaxValue, FixedTaxPerSlab = 54232, TaxChargeRate = 45 });

            return _taxSlabList;
        }

        /// <summary>
        /// .Function to get Tax Slab for salary
        /// </summary>
        /// <param name="salary"></param>
        /// <returns></returns>
        public TaxSlab GetTaxSlabDetails(double salary)
        {
            return SetTaxSlabs().FirstOrDefault(t => t.SlabUpperLimit >= salary);
        }

        /// <summary>
        /// Function to get Tax charge rate only
        /// </summary>
        /// <param name="salary"></param>
        /// <returns></returns>
        public double GetTaxChargeFromSlab(double salary)
        {
            return SetTaxSlabs().First(t => t.SlabUpperLimit <= salary).TaxChargeRate;
        }
    }
}
;