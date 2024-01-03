namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Registration")]
    public partial class Registration
    {
        public int id { get; set; }

        [StringLength(50)]
        public string firstname { get; set; }

        [StringLength(50)]
        public string lastname { get; set; }

        [StringLength(50)]
        public string nic { get; set; }

        public int? course_id { get; set; }

        public int? batch_id { get; set; }

        public int? telno { get; set; }

        public virtual Batch Batch { get; set; }

        public virtual Course Course { get; set; }

        public virtual Registration Registrations { get; set; }

        public virtual Registration Reistration2 { get; set; }
    }
}
