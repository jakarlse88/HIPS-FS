using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_FS.Models
{
    public partial class Movement
    {
        public Movement()
        {
            FormMovements = new HashSet<FormMovement>();
            MovementCategories = new HashSet<MovementCategory>();
        }

        public int Id { get; set; }
        public byte Term { get; set; }
        public int? HandTechniqueId { get; set; }
        public int? FootTechniqueId { get; set; }
        public int? StanceId { get; set; }

        public virtual ICollection<FormMovement> FormMovements { get; set; }
        public virtual ICollection<MovementCategory> MovementCategories { get; set; }
    }
}
