using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_FS.Models
{
    public partial class Family
    {
        public Family()
        {
            FamilyNames = new HashSet<FamilyName>();
            Forms = new HashSet<Form>();
        }

        public int Id { get; set; }

        public virtual ICollection<FamilyName> FamilyNames { get; set; }
        public virtual ICollection<Form> Forms { get; set; }
    }
}
