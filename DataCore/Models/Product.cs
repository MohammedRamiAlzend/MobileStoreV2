using DataCore.Models.SoftDelete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCore.Models
{
    public class Product : ISoftDelete
    {
        // Primary key
        public int Id { get; set; }

        // Name of the product
        public string? Name { get; set; }

        // Description of the product
        public string? Description { get; set; }

        // Price of the product
        public double Price { get; set; }

        // Discount on the product
        public double Discount { get; set; }

        // Path to the product image
        public string? ImagePath { get; set; }

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

        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; } = DateTime.UtcNow;

    }

}
