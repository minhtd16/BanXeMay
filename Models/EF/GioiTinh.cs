namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioiTinh")]
    public partial class GioiTinh
    {
        public byte iD { get; set; }

        [StringLength(5)]
        public string tenGT { get; set; }
    }
}
