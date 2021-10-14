namespace Testiranje
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OsobaT")]
    public partial class OsobaT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OsobaT()
        {
            OsobaT1 = new HashSet<OsobaT>();
            OsobaT11 = new HashSet<OsobaT>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string ime { get; set; }

        [Required]
        [StringLength(50)]
        public string prezime { get; set; }

        [Required]
        [StringLength(50)]
        public string adresa { get; set; }

        [Required]
        [StringLength(50)]
        public string telefon { get; set; }

        public int? idR { get; set; }

        public int? idS { get; set; }

        public int idB { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        public virtual BiografijaT BiografijaT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OsobaT> OsobaT1 { get; set; }

        public virtual OsobaT OsobaT2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OsobaT> OsobaT11 { get; set; }

        public virtual OsobaT OsobaT3 { get; set; }
    }
}
