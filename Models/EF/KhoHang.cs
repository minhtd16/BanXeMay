namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhoHang")]
    public partial class KhoHang
    {
        public long ID { get; set; }

        public int? MaKho { get; set; }

        [StringLength(20)]
        public string MaHH { get; set; }

        public int? SoLuong { get; set; }

        public virtual HangHoa HangHoa { get; set; }

        public virtual Kho Kho { get; set; }
    }
}
