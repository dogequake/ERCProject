using System;
using System.Collections.Generic;

#nullable disable

namespace ERCApi.Models
{
    public partial class Resident
    {
        public Resident()
        {
            Lcs = new HashSet<Lc>();
        }

        public long Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Birthday { get; set; }
        public string DateStartResidence { get; set; }
        public string DateEndResidence { get; set; }

        public virtual ICollection<Lc> Lcs { get; set; }
    }
}
