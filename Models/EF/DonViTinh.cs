namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonViTinh")]
    public partial class DonViTinh
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }
    }
}
