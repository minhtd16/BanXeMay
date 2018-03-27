namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiGiaoDich")]
    public partial class LoaiGiaoDich
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string TenGiaoDich { get; set; }
    }
}
