using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStoreV2.Models
{
    public class Sell
    {
        // Primary key
        public int Id { get; set; }

        // Total number of products in the sell
        public int TotalProducts { get; set; }

        // Total amount for the sell
        public double TotalAmount { get; set; }

        // Foreign key to the Bill entity
        public int BillId { get; set; }

        // Navigation property to the Bill entity
        public Bill? Bill { get; set; }

        // Foreign key to the Product entity
        public int ProductId { get; set; }

        // Navigation property to the Product entity
        public Product? Product { get; set; }
    }


}
