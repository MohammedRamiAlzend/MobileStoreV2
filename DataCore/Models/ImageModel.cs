using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCore.Models
{


    namespace DataCore.Models
    {
        public class ImageModel : ISoftDelete
        {
            public int Id { get; set; } // Primary Key
            public string ImageName { get; set; } // Name of the image
            public string ImagePath { get; set; } // Path image
            public DateTime UploadDate { get; set; } // Date of upload
            public ICollection<Product>? Products { get; set; }
            public bool IsDeleted { get; set; } = false;
            public DateTime? DeletedAt { get; set; } = null;

        }

    }


}
