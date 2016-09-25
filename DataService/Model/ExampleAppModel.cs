namespace DataService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ExampleAppModel : DbContext
    {
        public ExampleAppModel()
            : base("name=ExampleAppModel")
        {
        }

        public virtual DbSet<CompanyEntity> Companies { get; set; }
        public virtual DbSet<PersonEntity> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyEntity>()
                .Property(e => e.CompanyName)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyEntity>()
                .HasMany(e => e.Person)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PersonEntity>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<PersonEntity>()
                .Property(e => e.LastName)
                .IsUnicode(false);
        }
    }
}
