using System.ComponentModel.DataAnnotations;

namespace test_asp.net_Api.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Category { get; set; }

        [Required]
        // [Product_PriceRangeValue]
        public required double Price { get; set; }
    }
}
