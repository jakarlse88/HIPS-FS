using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_FS.Models
{
    public partial class Form
    {
        public Form()
        {
            FormDescriptions = new HashSet<FormDescription>();
            FormGroups = new HashSet<FormGroup>();
            FormMovements = new HashSet<FormMovement>();
            FormNames = new HashSet<FormName>();
            InverseSourceForm = new HashSet<Form>();
        }

        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatorId { get; set; }
        public int FamilyId { get; set; }
        public int? SeriesId { get; set; }
        public int SourceFormId { get; set; }

        public virtual Family Family { get; set; }
        public virtual Series Series { get; set; }
        public virtual Form SourceForm { get; set; }
        public virtual ICollection<FormDescription> FormDescriptions { get; set; }
        public virtual ICollection<FormGroup> FormGroups { get; set; }
        public virtual ICollection<FormMovement> FormMovements { get; set; }
        public virtual ICollection<FormName> FormNames { get; set; }
        public virtual ICollection<Form> InverseSourceForm { get; set; }
    }
}
