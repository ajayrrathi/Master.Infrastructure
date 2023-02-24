using System;
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
        public DbSet<Entity.ClientProduct> ClientProducts { get; set; }
        public DbSet<Entity.ClientCategories> ClientCatergories { get; set; }
        public DbSet<Entity.State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var userID = Guid.NewGuid();
            modelBuilder.ApplyConfiguration<Client>(new ClientConfiguration());

            #region Country
            modelBuilder.Entity<Entity.Country>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Entity.Country>()
                .Property(s => s.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.Country>()
                .Property(s => s.UpdatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.Country>()
                .Property(s => s.CreatedById)
                .HasDefaultValueSql(userID.ToString());

            modelBuilder.Entity<Entity.Country>()
                .Property(s => s.UpdatedByID)
                .HasDefaultValueSql(userID.ToString());

            //Relationship
            #endregion Country
            #region state
            modelBuilder.Entity<Entity.State>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Entity.State>()
                .Property(s => s.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.State>()
                .Property(s => s.UpdatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.State>()
                .Property(s => s.CreatedById)
                .HasDefaultValueSql(userID.ToString());

            modelBuilder.Entity<Entity.State>()
                .Property(s => s.UpdatedByID)
                .HasDefaultValueSql(userID.ToString());

            //Relationship
            modelBuilder.Entity<Entity.State>()
                .HasOne(c => c.Country)
                .WithMany( s => s.States)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientNoAction);

            #endregion state

            #region address
            modelBuilder.Entity<Entity.Address>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Entity.Address>()
                .Property(s => s.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.Address>()
                .Property(s => s.UpdatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.Address>()
                .Property(s => s.CreatedById)
                .HasDefaultValueSql(userID.ToString());

            modelBuilder.Entity<Entity.Address>()
                .Property(s => s.UpdatedByID)
                .HasDefaultValueSql(userID.ToString());

            //Relationship
            modelBuilder.Entity<Entity.Address>()
                .HasOne(c => c.State)
                .WithMany(a => a.Address)
                .OnDelete(DeleteBehavior.ClientNoAction);
            #endregion address

            #region Client
            modelBuilder.Entity<Entity.Client>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Entity.Client>()
                .Property(s => s.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.Client>()
                .Property(s => s.UpdatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.Client>()
                .Property(s => s.CreatedById)
                .HasDefaultValueSql(userID.ToString());

            modelBuilder.Entity<Entity.Client>()
                .Property(s => s.UpdatedByID)
                .HasDefaultValueSql(userID.ToString());

            //Relationship
            modelBuilder.Entity<Entity.Client>()
                .HasOne(c => c.Address)
                .WithMany(a => a.Clients)
                .OnDelete(DeleteBehavior.ClientNoAction);

           #endregion Client

            #region Product
            modelBuilder.Entity<Entity.Product>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Entity.Product>()
                .Property(s => s.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.Product>()
                .Property(s => s.UpdatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.Product>()
                .Property(s => s.CreatedById)
                .HasDefaultValueSql(userID.ToString());

            modelBuilder.Entity<Entity.Product>()
                .Property(s => s.UpdatedByID)
                .HasDefaultValueSql(userID.ToString());

            //Relationship
            #endregion Product 

            #region Category
            modelBuilder.Entity<Entity.Category>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Entity.Category>()
                .Property(s => s.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.Category>()
                .Property(s => s.UpdatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.Category>()
                .Property(s => s.CreatedById)
                .HasDefaultValueSql(userID.ToString());

            modelBuilder.Entity<Entity.Category>()
                .Property(s => s.UpdatedByID)
                .HasDefaultValueSql(userID.ToString());

            //Relationship
            #endregion Category

            #region Attribite
            modelBuilder.Entity<Entity.Attribute>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Entity.Attribute>()
                .Property(s => s.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.Attribute>()
                .Property(s => s.UpdatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.Attribute>()
                .Property(s => s.CreatedById)
                .HasDefaultValueSql(userID.ToString());

            modelBuilder.Entity<Entity.Attribute>()
                .Property(s => s.UpdatedByID)
                .HasDefaultValueSql(userID.ToString());

            //Relationship
            #endregion Attribute

            #region ClientCategories
            modelBuilder.Entity<Entity.ClientCategories>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Entity.ClientCategories>()
                .Property(s => s.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.ClientCategories>()
                .Property(s => s.UpdatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.ClientCategories>()
                .Property(s => s.CreatedById)
                .HasDefaultValueSql(userID.ToString());

            modelBuilder.Entity<Entity.ClientCategories>()
                .Property(s => s.UpdatedByID)
                .HasDefaultValueSql(userID.ToString());

            //Relationship
            modelBuilder.Entity<Entity.ClientCategories>()
                .HasOne(c => c.Category)
                .WithMany(cc => cc.ClientCatergories)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Entity.ClientCategories>()
                .HasOne(c => c.Client)
                .WithMany(cc => cc.ClientCategories)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientNoAction);
            #endregion ClientCategories

            #region ClientProduct
            modelBuilder.Entity<Entity.ClientProduct>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Entity.ClientProduct>()
                .Property(s => s.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.ClientProduct>()
                .Property(s => s.UpdatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.ClientProduct>()
                .Property(s => s.CreatedById)
                .HasDefaultValueSql(userID.ToString());

            modelBuilder.Entity<Entity.ClientProduct>()
                .Property(s => s.UpdatedByID)
                .HasDefaultValueSql(userID.ToString());

            //Relationship
            modelBuilder.Entity<Entity.ClientProduct>()
                .HasOne(c => c.Product)
                .WithMany(cp => cp.ClientProducts)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Entity.ClientProduct>()
                .HasOne(c => c.Client)
                .WithMany(cp => cp.ClientProduct)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientNoAction);
            #endregion ClientProduct

            #region ProductAttribute
            modelBuilder.Entity<Entity.ProductAttribute>()
                     .Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Entity.ProductAttribute>()
                .Property(s => s.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.ProductAttribute>()
                .Property(s => s.UpdatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.ProductAttribute>()
                .Property(s => s.CreatedById)
                .HasDefaultValueSql(userID.ToString());

            modelBuilder.Entity<Entity.ProductAttribute>()
                .Property(s => s.UpdatedByID)
                .HasDefaultValueSql(userID.ToString());

            //Relationship
            modelBuilder.Entity<Entity.ProductAttribute>()
                .HasOne(c => c.Product)
                .WithMany(pa => pa.ProductAttributes)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Entity.ProductAttribute>()
                .HasOne(c => c.Attribute)
                .WithMany(pa => pa.ProductAttributes)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientNoAction);
            #endregion ProductAttribute
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
