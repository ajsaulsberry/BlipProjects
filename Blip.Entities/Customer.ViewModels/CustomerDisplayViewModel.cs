using System;
using System.ComponentModel.DataAnnotations;

namespace Blip.Entities.Customer.ViewModels
{
    public class CustomerDisplayViewModel
    {
        [Display(Name = "Customer Number")]
        public Guid CustomerID { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Country")]
        public string CountryName { get; set; }

        [Display(Name = "State / Province / Region")]
        public string RegionName { get; set; }
    }
}