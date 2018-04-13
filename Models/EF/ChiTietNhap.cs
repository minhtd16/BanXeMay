namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietNhap")]
    public partial class ChiTietNhap
    {
        public long ID { get; set; }

        [Required]
        [StringLength(20)]
        public string NhapID { get; set; }

        [Required]
        [StringLength(20)]
        public string MaHH { get; set; }

        public int? SoLuong { get; set; }

        public decimal? DonGia { get; set; }

        public decimal? TongTien { get; set; }

        public int? MaKho { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public virtual HangHoa HangHoa { get; set; }

        public virtual NhapHang NhapHang { get; set; }
    }
}
