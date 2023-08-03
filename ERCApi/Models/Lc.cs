using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ERCApi.Models
{
    public partial class Lc
    {
        public long Id { get; set; }
        public string NumLc { get; set; }
        public byte[] DateStart { get; set; }
        public byte[] DateEnd { get; set; }
        public string Address { get; set; }
        public long AreaApart { get; set; }
        public long? ResidentId { get; set; }

        public virtual Resident Resident { get; set; }
    }
}
