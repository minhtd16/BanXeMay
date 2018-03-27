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

        public int? LoaiMH { get; set; }

        public int? NuocSXID { get; set; }

        [StringLength(200)]
        public string TenHH { get; set; }

        [StringLength(50)]
        public string DVT { get; set; }

        public int? MauID { get; set; }

        public int? SLTonToiThieu { get; set; }

        public int? HanBaoDong { get; set; }

        [StringLength(500)]
        public string ThongTin { get; set; }

        public long? GiaNhapVe { get; set; }

        public long? GiaBanLe { get; set; }

        public long? GiaBanSi { get; set; }

        public double? ThueSuat { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        [MaxLength(50)]
        public byte[] ModifiedBy { get; set; }

        public bool? Status { get; set; }
    }
}
