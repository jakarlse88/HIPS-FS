using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_FS.Models
{
    public partial class CategoryName
    {
        public int CategoryId { get; set; }
        public int NameId { get; set; }

        public virtual Category Category { get; set; }
    }
}
