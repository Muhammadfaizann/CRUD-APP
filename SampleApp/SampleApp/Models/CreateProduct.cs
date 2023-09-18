using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SampleApp.Models
{
     public class CreateProduct
     {
            [Required]
            public string Name { get; set; }
            [Required]
            public string Description { get; set; }
            [Required]
            [Range(1, 10000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
            public decimal Price { get; set; }
     }
}
