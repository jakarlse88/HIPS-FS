using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_FS.Models
{
    public partial class Series
    {
        public Series()
        {
            Forms = new HashSet<Form>();
            SeriesNames = new HashSet<SeriesName>();
        }

        public int Id { get; set; }

        public virtual ICollection<Form> Forms { get; set; }
        public virtual ICollection<SeriesName> SeriesNames { get; set; }
    }
}
