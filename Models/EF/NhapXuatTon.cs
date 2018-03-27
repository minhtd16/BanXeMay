namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhapXuatTon")]
    public partial class NhapXuatTon
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ngay { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Thang { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Nam { get; set; }

        [StringLength(20)]
        public string MaHH { get; set; }

        public int? MaKho { get; set; }

        public int? SLTD { get; set; }

        public int? SLN { get; set; }

        public int? SLX { get; set; }

        public int? SLTC { get; set; }

        public int? SLTT { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        [MaxLength(50)]
        public byte[] ModifiedBy { get; set; }
    }
}
