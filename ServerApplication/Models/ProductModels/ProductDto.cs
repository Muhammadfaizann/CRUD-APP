using System.ComponentModel.DataAnnotations;

namespace ServerApplication.Models
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; } = default!;
        [Required]
        public string Description { get; set; } = default!;
        [Required]
        [Range(1, 10000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal Price { get; set; }
    }
}

