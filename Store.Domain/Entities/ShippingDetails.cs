using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Store.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "What is your name?")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter the delivery dress")]
        [Display(Name="First address")]       
        public string Line1 { get; set; }
        [Display(Name = "Second address")]
        public string Line2 { get; set; }
        [Display(Name="Third address")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Enter city")]
        [Display(Name="City")]
        public string City { get; set;}

        [Required(ErrorMessage = "Enter country")]
        [Display(Name="Country")]
        public string Country {get; set;}

        // wrap - обгортка
        public bool GiftWrap { get; set; }


    }
}
