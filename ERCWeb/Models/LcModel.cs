using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERCWeb.Models
{
    public class LcModel
    {
        public long Id { get; set; }

        [Required]
        public string NumLc { get; set; }

        [Required]
        public string DateStart { get; set; }

        public string DateEnd { get; set; }

        [Required]
        [Display(Name = "Требуется адрес")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Требуется площадь")]
        public long AreaApart { get; set; }

        public long? ResidentId { get; set; }

        public ResidentModel Resident { get; set; }


    }
}
