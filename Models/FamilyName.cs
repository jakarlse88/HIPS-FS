using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_FS.Models
{
    public partial class FamilyName
    {
        public int FamilyId { get; set; }
        public int NameId { get; set; }

        public virtual Family Family { get; set; }
    }
}
