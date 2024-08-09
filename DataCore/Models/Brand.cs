﻿using DataCore.Models.SoftDelete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCore.Models
{
    public class Brand:ISoftDelete
    {
        // Primary key
        public int Id { get; set; }

        // Name of the brand
        public string? Name { get; set; }

        // Navigation property to the collection of Product entities
        public ICollection<Product>? Products { get; set; }

        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; } = null;

    }

}
