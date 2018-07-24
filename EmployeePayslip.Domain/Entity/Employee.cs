using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmployeePayslip.Domain.Entity
{
    public class Employee
    {
        [Required(ErrorMessage = "Firstname required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Annual salary required")]
        [Range(0, double.MaxValue)]
        public double AnnualSalary { get; set; }

        [Required(ErrorMessage = "Payment start date reqired")]
        public string PaymentStartDate { get; set; }

        [Required(ErrorMessage = "Super rate required")]
        [Range(0, double.MaxValue)]
        public double SuperRate { get; set; }
    }
}
