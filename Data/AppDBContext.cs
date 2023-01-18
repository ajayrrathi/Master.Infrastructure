using MasterProject.Core.Entities;
using MasterProject.Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;
using Entity = MasterProject.Core.Entities;

namespace MasterProject.Infrastructure.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Entity.Address> Addresses { get; set; }
        public DbSet<Entity.Attribute> Attributes { get; set; }

        public DbSet<Entity.Category> Categories { get; set; }
        public DbSet<Entity.Client> Clients { get; set; }
        public DbSet<Entity.Country> Countries { get; set; }
        public DbSet<Entity.PhoneNumber> PhoneNumbers { get; set; }

        public DbSet<Entity.Product> Products { get; set; }
        public DbSet<Entity.ProductAttribute> ProductAttributes { get; set; }
        public DbSet<Entity.ProductCatergories> ProductCatergories { get; set; }
        public DbSet<Entity.State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Client>(new ClientConfiguration());

            modelBuilder.Entity<Entity.ProductAttribute>()
                .HasOne(c => c.Product)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Entity.ProductAttribute>()
                .HasOne(c => c.Attribute)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Entity.ProductCatergories>()
                .HasOne(c => c.CategoryProduct)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Entity.ProductCatergories>()
                .HasOne(c => c.Category)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientNoAction);


            modelBuilder.Entity<Entity.Address>()
                     .Property(s => s.CreatedOn)
                     .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.Address>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");



            modelBuilder.Entity<Entity.Product>()
                     .Property(s => s.CreatedOn)
                     .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.Product>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");


            modelBuilder.Entity<Entity.Attribute>()
                     .Property(s => s.CreatedOn)
                     .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.Attribute>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");


            modelBuilder.Entity<Entity.ProductAttribute>()
                    .Property(s => s.CreatedOn)
                    .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.ProductAttribute>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Entity.Category>()
                .Property(s => s.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.Category>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Entity.Country>()
                    .Property(s => s.CreatedOn)
                    .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Entity.Country>()
                    .Property(s => s.CreatedOn)
                    .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.ProductCatergories>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");


            modelBuilder.Entity<Entity.ProductCatergories>()
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
