using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_FS.Models
{
    public partial class FormGroup
    {
        public int FormId { get; set; }
        public int GroupId { get; set; }

        public virtual Form Form { get; set; }
    }
}
