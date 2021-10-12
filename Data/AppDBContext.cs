using MasterProject.Core.Entities;
using MasterProject.Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;
using entity = MasterProject.Core.Entities;

namespace MasterProject.Infrastructure.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<entity.Address> Addresses { get; set; }
        public DbSet<entity.Attribute> Attributes { get; set; }

        public DbSet<entity.Category> Categories { get; set; }
        public DbSet<entity.Client> Clients { get; set; }
        public DbSet<entity.Country> Countries { get; set; }
        public DbSet<entity.PhoneNumber> PhoneNumbers { get; set; }

        public DbSet<entity.Product> Products { get; set; }
        public DbSet<entity.ProductAttribute> ProductAttributes { get; set; }
        public DbSet<entity.ProductCatergories> ProductCatergories { get; set; }
        public DbSet<entity.State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Client>(new ClientConfiguration());

            modelBuilder.Entity<entity.ProductAttribute>()
                .HasOne(c => c.Product)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<entity.ProductAttribute>()
                .HasOne(c => c.Attribute)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<entity.ProductCatergories>()
                .HasOne(c => c.CategoryProduct)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<entity.ProductCatergories>()
                .HasOne(c => c.Category)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientNoAction);


            modelBuilder.Entity<entity.Address>()
                     .Property(s => s.CreatedOn)
                     .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<entity.Address>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");



            modelBuilder.Entity<entity.Product>()
                     .Property(s => s.CreatedOn)
                     .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<entity.Product>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");


            modelBuilder.Entity<entity.Attribute>()
                     .Property(s => s.CreatedOn)
                     .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<entity.Attribute>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");


            modelBuilder.Entity<entity.ProductAttribute>()
                    .Property(s => s.CreatedOn)
                    .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<entity.ProductAttribute>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<entity.Category>()
                .Property(s => s.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<entity.Category>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<entity.Country>()
                    .Property(s => s.CreatedOn)
                    .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<entity.Country>()
                    .Property(s => s.CreatedOn)
                    .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<entity.ProductCatergories>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");


            modelBuilder.Entity<entity.ProductCatergories>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");
            //modelBuilder.Entity<entity.ProductCatergories>()
            //    .HasOne(c => c.Category)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.ClientCascade);


            //modelBuilder.Entity<entity.ProductCatergories>()
            //    .HasOne(c => c.Product)
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.ClientCascade);

            //modelBuilder.Entity<ProductAttribute>()
            //    .HasOne(c => c.Product)
            //    .WithOne();
            //modelBuilder.Entity<ProductAttribute>()
            //   .HasOne(c => c.Attribute)
            //   .WithOne();

        }
    }
}
