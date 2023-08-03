using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERCWeb.Models
{
    public class ResidentModel
    {
        public ResidentModel()
        {
            Lcs = new HashSet<LcModel>();
        }

        public long Id { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Patronymic { get; set; }
        [Required]
        public string Birthday { get; set; }
        [Required]
        public string DateStartResidence { get; set; }
        public string DateEndResidence { get; set; }

        public virtual ICollection<LcModel> Lcs { get; set; }
    }
}
