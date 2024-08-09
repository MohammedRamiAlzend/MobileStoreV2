﻿
using DataCore.Models.SoftDelete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCore.Models
{
    public class Category:ISoftDelete
    {
        // Primary key
        public int Id { get; set; }

        // Name of the category (required)
        public required string Name { get; set; }

        // Navigation property to the collection of Product entities
        public ICollection<Product>? Products { get; set; }

        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; } = null;
    }

}
