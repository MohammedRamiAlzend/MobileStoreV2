﻿
namespace DataCore.Models
{
    public class Bill : ISoftDelete
    {
        // Primary key
        public int Id { get; set; }

        // Discount applied to the bill
        public double Discount { get; set; }

        // Total amount before discount
        public double Total { get; set; }

        // Final total amount after discount
        public double FinalTotal { get; set; }

        // Date of the bill
        public DateTime Date { get; set; }

        // Navigation property to the collection of Sell entities
        public ICollection<Sell>? Sells { get; set; }

        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; } = null;

    }

}
