using System;
using EmployeePayslip.Api.Controllers;
using EmployeePayslip.BusinessLogic.Abstract;
using EmployeePayslip.Domain.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Moq;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace EmployeePayslip.Api.Test
{
    [TestFixture]
    public class PayslipControllerTest
    {
        private Mock<ITaxCalculator> _mockTax = null;
        [SetUp]
        public void SetUp()
        {
            _mockTax = new Mock<ITaxCalculator>();
        }


        [TestCase]
        public void PayslipController_API_Request()
        {
            var employee = new Employee { FirstName = "Ram", LastName = "Kumar", AnnualSalary = 10, PaymentStartDate = "sd", SuperRate = 0 };

            var target = new PayslipController(_mockTax.Object);
            var result = target.Post(employee) ;
        }
    }
}
