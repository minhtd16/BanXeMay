namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemLog")]
    public partial class SystemLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        public int? UserID { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(20)]
        public string Table { get; set; }

        [StringLength(50)]
        public string Column { get; set; }

        [StringLength(500)]
        public string OldContent { get; set; }

        [StringLength(500)]
        public string NewContent { get; set; }
    }
}
