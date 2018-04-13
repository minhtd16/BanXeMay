namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HangHoa")]
    public partial class HangHoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HangHoa()
        {
            ChiTietNhaps = new HashSet<ChiTietNhap>();
            ChiTietXuats = new HashSet<ChiTietXuat>();
            KhoHangs = new HashSet<KhoHang>();
        }

        [Key]
        [StringLength(20)]
        public string MaHH { get; set; }

        [StringLength(10)]
        public string LoaiMH { get; set; }

        public int? NuocSXID { get; set; }

        [Required]
        [StringLength(200)]
        public string TenHH { get; set; }

        public int? DVT { get; set; }

        public int? MauID { get; set; }

        [StringLength(500)]
        public string Anh { get; set; }

        public int? SoLuong { get; set; }

        public int? TonToiThieu { get; set; }

        public int? TonToiDa { get; set; }

        public int? HanBaoDong { get; set; }

        [StringLength(500)]
        public string ThongTin { get; set; }

        public decimal? GiaNhapVe { get; set; }

        public decimal? GiaBanLe { get; set; }

        public decimal? GiaBanSi { get; set; }

        public double? ThueSuat { get; set; }

        public bool? TinhTonKho { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public bool? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietNhap> ChiTietNhaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietXuat> ChiTietXuats { get; set; }

        public virtual DonViTinh DonViTinh { get; set; }

        public virtual DonViTinh DonViTinh1 { get; set; }

        public virtual LoaiMatHang LoaiMatHang { get; set; }

        public virtual MauSac MauSac { get; set; }

        public virtual NuocSanXuat NuocSanXuat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoHang> KhoHangs { get; set; }
    }
}
