namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaCungCapGiaoDich")]
    public partial class NhaCungCapGiaoDich
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [StringLength(20)]
        public string GiaoDichID { get; set; }

        [StringLength(50)]
        public string NhaCungCapID { get; set; }

        public DateTime? NgayGiaoDich { get; set; }

        public int? SoLuong { get; set; }

        public decimal? TongTien { get; set; }

        [StringLength(100)]
        public string TrangThai { get; set; }
    }
}
