using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStoreV2.Models
{
    public class Brand
    {
        // Primary key
        public int Id { get; set; }

        // Name of the brand
        public string Name { get; set; }

        // Navigation property to the collection of Product entities
        public ICollection<Product>? Products { get; set; }
    }

}
