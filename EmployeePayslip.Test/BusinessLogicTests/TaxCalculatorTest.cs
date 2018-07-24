using System;
using NUnit.Framework;
using Moq;
using EmployeePayslip.BusinessLogic.Abstract;
using EmployeePayslip.BusinessLogic.Concrete;
using EmployeePayslip.BusinessLogic.Response;
using EmployeePayslip.Domain.Entity;
using EmployeePayslip.Repository.Abstract;
using EmployeePayslip.Repository.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace EmployeePayslip.Test.BusinessLogicTests
{
    [TestFixture]
    public class TaxCalculatorTest
    {
        //[TestCase]
        //[ExpectedException(typeof(NullReferenceException), "empPaySlipRepo can not be null")]
        //public void TaxCalculator_Ctor_Null_Check()
        //{
        //    var taxCalculator = new TaxCalculator(null);
        //    Assert.Fail("empPaySlipRepo can not be null");;
        //}

        
        [TestCase(18200, 0, 0, 18200, 0, 0)]
        [TestCase(19000, 18201, 37000, 0, 19, 13)]
        [TestCase(60050, 37001, 87000, 3572, 32.5, 922)]
        [TestCase(90000, 87001, 180000, 19822, 37, 1744)]
        [TestCase(0, 0, 0, 0, 0, 0)]
        [TestCase(-1, 0, 0, 0, 0, 0)]
        public void TaxCalculator_GetTaxSlabs(double annualSalary, double slabLowerLimit, double slabUpperLimit, double fixedTaxSlab, double taxChargeRate , double actualResult)
        {
            var emp = new Employee
            {
                FirstName = "Ram",
                LastName = "Kumar",
                AnnualSalary = annualSalary,
                PaymentStartDate = "1 March - 31 March",
                SuperRate = 9
            };


            var mockRepo = new Mock<IEmployeePayslipRepository>();

            var mockTaxCalculator = new Mock<ITaxCalculator>();

            mockRepo.Setup(x => x.GetTaxSlabDetails(emp.AnnualSalary)).Returns(new TaxSlab
            {
                SlabLowerLimit = slabLowerLimit,
                SlabUpperLimit = slabUpperLimit,
                FixedTaxPerSlab = fixedTaxSlab,
                TaxChargeRate = taxChargeRate
            });

            mockTaxCalculator.Setup(x => x.EmployeePaySlip(emp)).Returns(It.IsAny<EmployeeResponse>());

            var taxCalculator = new TaxCalculator(mockRepo.Object);

            var result = taxCalculator.EmployeePaySlip(emp);
            Assert.AreEqual(actualResult, result.IncomeTax);
        }
    }
}
