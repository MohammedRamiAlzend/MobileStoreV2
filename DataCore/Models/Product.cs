using DataCore.Models.DataCore.Models;
using System.ComponentModel.DataAnnotations;

namespace DataCore.Models
{
    public class Product : ISoftDelete
    {
        // Primary key
        public int Id { get; set; }

        // Name of the product
        [Required]
        [StringLength(30, ErrorMessage = "Name Failed Is Required.", MinimumLength = 3)]
        public string? Name { get; set; }

        // Description of the product
        
        public string? Description { get; set; }

        // Buy of the product
        [Required]
        [Range(1, 10000000000000000000,  ErrorMessage = "must be greater than 0.")]
        public double BuyPrice { get; set; }

        // Sell of the product
        [Required]
        [Range(1, 10000000000000000000, ErrorMessage = "must be greater than 0.")]

        public double SellPrice { get; set; }


        // Path to the product image
        //public string? ImagePath { get; set; }

        // Foreign key to the image entity
        public int ImageId { get; set; }


        // Navigation property to the Image entity
        public ImageModel? Image { get; set; }
        // Quantity of the product in stock

        [Required]
        [Range(1, 10000000000000000000, ErrorMessage = "must be greater than 0.")]
        public int Quantity { get; set; }

        // Bar code of the product
        [Required]
        [Range(1, 100000000000000, ErrorMessage = "must be greater than 0.")]
        public int BarCode { get; set; }

        // Date when the product was inserted
        public DateTime InsertDate { get; set; }

        // Foreign key to the Brand entity
        public int BrandId { get; set; }


        // Navigation property to the Brand entity
        public Brand? Brand { get; set; }

        // Foreign key to the Category entity
        public int CategoryId { get; set; }

        // Navigation property to the Category entity
        public Category? Category { get; set; }

        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; } = null;

    }

}
