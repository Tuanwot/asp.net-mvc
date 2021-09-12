namespace assignmentv2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trainer")]
    public partial class Trainer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public int? Age { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Dob { get; set; }

        [StringLength(255)]
        public string Education { get; set; }

        [StringLength(50)]
        public string MainprogrammingLanguage { get; set; }

        public int? TOEICscore { get; set; }

        [StringLength(50)]
        public string Experience { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        [StringLength(255)]
        public string location { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int? AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}
