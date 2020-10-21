using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace Food.Product.Dto
{
    [AutoMapTo(typeof(Ordering.Product))]
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(0,1000)]
        public decimal PriceNet { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [Required]
        [Range(1,1000)]
        public int TaxId { get; set; }
    }
}
