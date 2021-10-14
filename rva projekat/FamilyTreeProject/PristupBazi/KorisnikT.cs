namespace PristupBazi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KorisnikT")]
    public partial class KorisnikT : Model
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(50)]
        public string ime { get; set; }

        [Required]
        [StringLength(50)]
        public string prezime { get; set; }

        public int tip { get; set; }

        [Required]
        [StringLength(50)]
        public string lozinka { get; set; }
    }
}
