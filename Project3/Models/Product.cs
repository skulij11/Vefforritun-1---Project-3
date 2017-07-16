using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project3.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]        
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        
        public string Description { get; set; }
        public int Category { get; set; }

        [Range(0.0,Double.MaxValue, ErrorMessage = "Price cannot be negative.")]
        public int Price { get; set; }

        [Range(0.0, Double.MaxValue, ErrorMessage = "Stock cannot be negative.")]
        public int Stock { get; set; }
        
    }
}