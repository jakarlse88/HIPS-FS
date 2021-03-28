using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_FS.Models
{
    public partial class Description
    {
        public Description()
        {
            FormDescriptions = new HashSet<FormDescription>();
        }

        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int LanguageId { get; set; }

        public virtual ICollection<FormDescription> FormDescriptions { get; set; }
    }
}
