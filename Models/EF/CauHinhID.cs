namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CauHinhID")]
    public partial class CauHinhID
    {
        [StringLength(50)]
        public string ID { get; set; }

        public long Value { get; set; }
    }
}
