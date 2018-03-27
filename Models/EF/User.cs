namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string SaltPass { get; set; }

        [Required]
        [StringLength(200)]
        public string Password { get; set; }

        public bool? Remember { get; set; }

        [StringLength(20)]
        public string GroupID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? BirthDay { get; set; }

        public bool? Gender { get; set; }

        [StringLength(200)]
        public string Avatar { get; set; }

        [StringLength(100)]
        public string Website { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        public bool? Status { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ModifiedDate { get; set; }
    }
}
