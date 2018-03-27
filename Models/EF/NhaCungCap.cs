namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaCungCap")]
    public partial class NhaCungCap
    {
        [Key]
        [StringLength(50)]
        public string MaNCC { get; set; }

        [StringLength(100)]
        public string TenNCC { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(20)]
        public string DiDong { get; set; }

        [StringLength(20)]
        public string SDT1 { get; set; }

        [StringLength(20)]
        public string SDT2 { get; set; }

        [StringLength(20)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string Website { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string MaSoThue { get; set; }

        [StringLength(10)]
        public string TongTienGiaoDich { get; set; }
    }
}
