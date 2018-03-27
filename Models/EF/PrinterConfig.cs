namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PrinterConfig")]
    public partial class PrinterConfig
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Top { get; set; }

        public int? Left { get; set; }

        public int? Right { get; set; }

        public int? Bottom { get; set; }

        public int? WidthCell { get; set; }

        public int? HeightCell { get; set; }

        public int? Row { get; set; }

        public int? Column { get; set; }
    }
}
