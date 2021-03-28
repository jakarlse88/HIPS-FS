using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_FS.Models
{
    public partial class FormDescription
    {
        public int FormId { get; set; }
        public int DescriptionId { get; set; }

        public virtual Description Description { get; set; }
        public virtual Form Form { get; set; }
    }
}
