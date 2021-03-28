using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_FS.Models
{
    public partial class SeriesName
    {
        public int SeriesId { get; set; }
        public int NameId { get; set; }

        public virtual Series Series { get; set; }
    }
}
