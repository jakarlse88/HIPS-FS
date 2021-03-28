using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_FS.Models
{
    public partial class MovementCategory
    {
        public int MovementId { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Movement Movement { get; set; }
    }
}
