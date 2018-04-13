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

        public int? MaKho { get; set; }

        [Required]
        [StringLength(20)]
        public string XuatID { get; set; }

        [Required]
        [StringLength(20)]
        public string MaHH { get; set; }

        public int? SoLuong { get; set; }

        public decimal? DonGia { get; set; }

        public decimal? ThanhTien { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public virtual HangHoa HangHoa { get; set; }

        public virtual XuatHang XuatHang { get; set; }
    }
}
