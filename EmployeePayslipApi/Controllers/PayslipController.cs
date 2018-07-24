using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeePayslip.BusinessLogic.Abstract;
using EmployeePayslip.Domain.Entity;

namespace EmployeePayslipApi.Controllers
{
    public class PayslipController : ApiController
    {
        private ITaxCalculator _taxCalculator;

        public PayslipController(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        public IHttpActionResult Get(Employee employee)
        {
            var response = _taxCalculator.EmployeePaySlip(employee);
            return Ok(response);
        }
    }
}
