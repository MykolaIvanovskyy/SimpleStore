using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Store.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage ="Please enter the name of the product")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        [Required(ErrorMessage ="Please enter a description for the product")]
        public string Description { get;set;}

        [Display(Name ="Category")]
        [Required(ErrorMessage ="Please select the category for the product")]
        public string Category { get; set; }


        [Display(Name ="Price (grn)")]
        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage ="Please enter a positive value for the price")]
        public decimal Price { get; set; }

        public byte[] ImageData { get; set; }

        [MaxLength(50)]
        public string ImageMimeType { get; set; }

    }
}
