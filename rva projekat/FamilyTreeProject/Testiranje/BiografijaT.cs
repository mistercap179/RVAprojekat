namespace Testiranje
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BiografijaT")]
    public partial class BiografijaT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BiografijaT()
        {
            OsobaT = new HashSet<OsobaT>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nivoObrazovanje { get; set; }

        [Required]
        [StringLength(50)]
        public string iskustvo { get; set; }

        [Required]
        [StringLength(50)]
        public string vjestine { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OsobaT> OsobaT { get; set; }
    }
}
