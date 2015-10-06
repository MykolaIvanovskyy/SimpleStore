using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.WebUI.Models
{
    public class PagingInfo
    {
        // quantity product
        public int TotalItems { get; set; }
        // quantity  product on one page
        public int ItemPerPage { get; set; }
        // number page
        public int CurrentPage { get; set; }
        // total quantity pages
        public int TotalPages 
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemPerPage); }
        }
    }
}