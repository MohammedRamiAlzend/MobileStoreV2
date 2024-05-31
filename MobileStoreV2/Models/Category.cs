
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStoreV2.Models
{
    public class Category
    {
        // Primary key
        public int Id { get; set; }

        // Name of the category (required)
        public required string Name { get; set; }

        // Navigation property to the collection of Product entities
        public ICollection<Product>? Products { get; set; }
    }

}
