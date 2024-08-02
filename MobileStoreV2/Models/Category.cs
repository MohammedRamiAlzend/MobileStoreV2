
using MobileStoreV2.Models.SoftDelete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStoreV2.Models
{
    public class Category:ISoftDelete
    {
        // Primary key
        public int Id { get; set; }

        // Name of the category (required)
        public required string Name { get; set; }

        // Navigation property to the collection of Product entities
        public ICollection<Product>? Products { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; } = DateTime.UtcNow;
    }

}
