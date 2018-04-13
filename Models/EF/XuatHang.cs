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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XuatHang()
        {
            ChiTietXuats = new HashSet<ChiTietXuat>();
        }

        [Key]
        [StringLength(20)]
        public string IDXuat { get; set; }

        public DateTime? NgayXuat { get; set; }

        [StringLength(50)]
        public string NguoiLapPhieu { get; set; }

        public int? KhachHang { get; set; }

        public int? LoaiGiaoDichID { get; set; }

        [StringLength(50)]
        public string ThuKho { get; set; }

        [StringLength(200)]
        public string DienGiai { get; set; }

        public decimal? TongTien { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public int? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietXuat> ChiTietXuats { get; set; }

        public virtual KhachHang KhachHang1 { get; set; }
    }
}
