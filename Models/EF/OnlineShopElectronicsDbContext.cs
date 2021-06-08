using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.EF
{
    public partial class OnlineShopElectronicsDbContext : DbContext
    {
        public OnlineShopElectronicsDbContext()
            : base("name=OnlineShopElectronicsDbContext")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplierss> Suppliersses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.FaxNumber)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.PhoneContactPerson)
                .IsUnicode(false);

           

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.ProductCategory)
                .HasForeignKey(e => e.CategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplierss>()
                .Property(e => e.Zip_Code)
                .IsFixedLength();

            modelBuilder.Entity<Supplierss>()
                .Property(e => e.PhoneContactPerson)
                .IsUnicode(false);

            modelBuilder.Entity<Supplierss>()
                .Property(e => e.EmailContactPerson)
                .IsUnicode(false);

            modelBuilder.Entity<Supplierss>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Supplierss)
                .HasForeignKey(e => e.SupplierID);
        }

        public System.Data.Entity.DbSet<Models.ViewModel.ProductViewModel> ProductViewModels { get; set; }
    }
}
