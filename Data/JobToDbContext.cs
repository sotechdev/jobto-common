using JobTo.Commom.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JobTo.Commom.Data
{
    public partial class JobToDbContext : DbContext
    {
        public JobToDbContext()
        {
        }

        public JobToDbContext(DbContextOptions<JobToDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonGroup> PersonGroups { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<QuoteProduct> QuoteProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Portuguese_Brazil.1252");

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Grid)
                    .HasDefaultValueSql("nextval('grid_seq'::regclass)");

                entity.Property(e => e.Flag)
                    .IsRequired()
                    .HasDefaultValue('A');

                entity.Property(e => e.PersonType)
                    .HasDefaultValue("C")
                    .HasComment("Person types:\n\n - 'C' : Client\n - 'E' : Employee\n - 'P' : Provider\n - 'B' : Business");
            });

            modelBuilder.Entity<PersonGroup>(entity =>
            {
                entity.Property(e => e.Grid)
                    .HasDefaultValueSql("nextval('grid_seq'::regclass)");

                entity.Property(e => e.PersonType)
                    .HasDefaultValue("C");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                modelBuilder.HasSequence("grid_seq");

                entity.Property(e => e.Grid)
                    .HasDefaultValueSql("nextval('grid_seq'::regclass)");

                entity.Property(e => e.Flag)
                    .HasDefaultValue('A')
                    .HasComment("Flag values:\n\n - 'A' : Active\n - 'I' : Inactive\n - 'B' : Blocked\n - 'D' : Deleted");

                entity.Property(e => e.ProductType)
                    .HasDefaultValue('P')
                    .HasComment("Product types:\n\n - 'P' : Product\n - 'S' : Service");

                entity.Property(e => e.PurchasePrice)
                    .HasColumnType("money");

                entity.Property(e => e.SalePrice)
                    .HasColumnType("money");

                entity.Property(e => e.Uom)
                    .HasDefaultValue("UN")
                    .HasComment("UOM - Units of Measurement");
            });

            modelBuilder.Entity<Quote>(entity =>
            {

                entity.Property(e => e.Grid)
                    .HasDefaultValueSql("nextval('grid_seq'::regclass)");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("money");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.QuoteClients)
                    .HasForeignKey(d => d.ClientId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.QuoteEmployees)
                    .HasForeignKey(d => d.EmployeeId);
            });

            modelBuilder.Entity<QuoteProduct>(entity =>
            {

                entity.Property(e => e.Grid)
                    .HasDefaultValueSql("nextval('grid_seq'::regclass)");

                entity.Property(e => e.Price)
                    .HasColumnType("money");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.QuoteProducts)
                    .HasForeignKey(d => d.ProductId);
            });           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
