using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperSkillsAssessment.API.Models
{
    public class Account
    {
        public int code { get; set; }
        public int person_code { get; set; }
        public string account_number { get; set; }
        public decimal outstanding_balance { get; set; }
        public Boolean is_closed { get; set; }
        public int status_id { get; set; }
    }
}
