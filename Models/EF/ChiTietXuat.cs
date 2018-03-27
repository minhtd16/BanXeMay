namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietXuat")]
    public partial class ChiTietXuat
    {
        public long ID { get; set; }

        public long? XuatID { get; set; }

        [StringLength(20)]
        public string MaHH { get; set; }

        public int? SoLuongYC { get; set; }

        public int? SoLuongThuc { get; set; }

        public long? DonGia { get; set; }

        public int? MaKho { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        [MaxLength(50)]
        public byte[] ModifiedBy { get; set; }
    }
}
