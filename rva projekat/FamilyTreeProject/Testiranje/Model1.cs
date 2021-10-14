namespace Testiranje
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<BiografijaT> BiografijaT { get; set; }
        public virtual DbSet<KorisnikT> KorisnikT { get; set; }
        public virtual DbSet<OsobaT> OsobaT { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BiografijaT>()
                .HasMany(e => e.OsobaT)
                .WithRequired(e => e.BiografijaT)
                .HasForeignKey(e => e.idB)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OsobaT>()
                .HasMany(e => e.OsobaT1)
                .WithOptional(e => e.OsobaT2)
                .HasForeignKey(e => e.idR);

            modelBuilder.Entity<OsobaT>()
                .HasMany(e => e.OsobaT11)
                .WithOptional(e => e.OsobaT3)
                .HasForeignKey(e => e.idS);
        }
    }
}
