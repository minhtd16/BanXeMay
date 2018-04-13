namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhapHang")]
    public partial class NhapHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhapHang()
        {
            ChiTietNhaps = new HashSet<ChiTietNhap>();
        }

        [Key]
        [StringLength(20)]
        public string IDNhap { get; set; }

        public DateTime? NgayNhap { get; set; }

        public int? DoiTac { get; set; }

        [StringLength(50)]
        public string NguoiLapPhieu { get; set; }

        [StringLength(50)]
        public string NguoiGiaoHang { get; set; }

        [StringLength(500)]
        public string DienGiai { get; set; }

        public int? LoaiGiaoDichID { get; set; }

        public decimal? TongTien { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        [MaxLength(50)]
        public byte[] ModifiedBy { get; set; }

        public int? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietNhap> ChiTietNhaps { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}
