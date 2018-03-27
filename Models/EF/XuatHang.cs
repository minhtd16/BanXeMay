namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XuatHang")]
    public partial class XuatHang
    {
        [Key]
        public long IDXuat { get; set; }

        public DateTime? NgayNhap { get; set; }

        [StringLength(50)]
        public string NguoiLapPhieu { get; set; }

        [StringLength(50)]
        public string NguoiNhanHang { get; set; }

        [StringLength(50)]
        public string ThuKho { get; set; }

        [StringLength(50)]
        public string KeToan { get; set; }

        [StringLength(50)]
        public string TruongDonVi { get; set; }

        public decimal? TongTien { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        [MaxLength(50)]
        public byte[] ModifiedBy { get; set; }
    }
}
