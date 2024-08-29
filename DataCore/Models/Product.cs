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
        public string? Name { get; set; }

        // Description of the product
        public string? Description { get; set; }

        // Buy of the product


        public double BuyPrice { get; set; }

        // Sell of the product


        public double SellPrice { get; set; }

        // Discount on the product
        public double Discount { get; set; }

        // Path to the product image
        //public string? ImagePath { get; set; }

        // Foreign key to the image entity
        public int ImageId { get; set; }


        // Navigation property to the Image entity
        public ImageModel? Image { get; set; }
        // Quantity of the product in stock


        public int Quantity { get; set; }

        // Bar code of the product


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
