using System;
using System.ComponentModel.DataAnnotations;

namespace Fsd_Mvc_Assign.Models
{
    public class Customer
    {
        [Display(Name = "Customer Id")]
        public string CustId { get; set; }

        [Display(Name = "Customer Name")]
        public String CustName { get; set; }

        [Display(Name = "Customer Address")]
        public String CustAddress { get; set; }

        [Display(Name = "Date Of Birth")]
        public String DoB { get; set; }

        [Display(Name = "Salary")]
        public Decimal Salary { get; set; }
    }
}