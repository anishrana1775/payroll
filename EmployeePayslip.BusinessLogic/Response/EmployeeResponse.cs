using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EmployeePayslip.BusinessLogic.Response
{
    public class EmployeeResponse
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "pay-period")]
        public string PayPeriod { get; set; }

        [JsonProperty(PropertyName = "gross-income")]
        public double GrossIncome { get; set; }

        [JsonProperty(PropertyName = "income-tax")]
        public double IncomeTax { get; set; }

        [JsonProperty(PropertyName = "net-income")]
        public double NetIncome { get; set; }

        [JsonProperty(PropertyName = "super-amount")]
        public double SuperAmount { get; set; }
    }
}
