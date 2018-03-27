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

        public long? GiaNhapVe { get; set; }

        public long? GiaBanLe { get; set; }

        public long? GiaBanSi { get; set; }

        public double? ThueSuat { get; set; }

        public bool TinhTonKho { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public bool? Status { get; set; }
    }
}
