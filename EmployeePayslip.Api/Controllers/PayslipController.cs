using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeePayslip.BusinessLogic.Abstract;
using EmployeePayslip.BusinessLogic.Response;
using EmployeePayslip.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePayslip.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Payslip")]
    public class PayslipController : Controller
    {
        private ITaxCalculator _taxCalculator;

        public PayslipController(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Employee employee)
        {
            if (ModelState.IsValid)
            {
                var response = _taxCalculator.EmployeePaySlip(employee);
                return Ok(response);
            }

            return BadRequest();
        }
    }
}