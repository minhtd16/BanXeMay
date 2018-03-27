namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHangGiaoDich")]
    public partial class KhachHangGiaoDich
    {
        public long ID { get; set; }

        [StringLength(20)]
        public string DonHangID { get; set; }

        public int? KhachHangID { get; set; }

        public DateTime? NgayGiaoDich { get; set; }

        public decimal? TongTien { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(100)]
        public string TrangThai { get; set; }
    }
}
