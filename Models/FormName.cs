using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_FS.Models
{
    public partial class FormName
    {
        public int NameId { get; set; }
        public int FormId { get; set; }

        public virtual Form Form { get; set; }
    }
}
