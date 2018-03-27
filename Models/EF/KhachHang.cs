namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string TenKH { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        public int? LoaiKH { get; set; }

        public decimal? TongTienGiaoDich { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        [MaxLength(50)]
        public byte[] ModifiedBy { get; set; }
    }
}
