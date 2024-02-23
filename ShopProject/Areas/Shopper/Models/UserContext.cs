using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ShopProject.Areas.Shopper.Models
{
    public partial class UserContext : DbContext
    {
        public UserContext()
            : base("name=UserContextv2")
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderStatuses> OrderStatuses { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Producers> Producers { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductTypes> ProductTypes { get; set; }
        public virtual DbSet<Rates> Rates { get; set; }
        public virtual DbSet<ShippingDetails> ShippingDetails { get; set; }
        public virtual DbSet<ShoppingCartItems> ShoppingCartItems { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>()
                .Property(e => e.proID)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.cusPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.cusEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .HasMany(e => e.ShoppingCartItems)
                .WithRequired(e => e.Customers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetails>()
                .Property(e => e.orderID)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetails>()
                .Property(e => e.proID)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetails>()
                .Property(e => e.ordtsThanhTien)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.orderID)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.cusPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.orderDateTime)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Orders)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orders>()
                .HasMany(e => e.Payments)
                .WithRequired(e => e.Orders)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orders>()
                .HasOptional(e => e.ShippingDetails)
                .WithRequired(e => e.Orders);

            modelBuilder.Entity<Payments>()
                .Property(e => e.orderID)
                .IsUnicode(false);

            modelBuilder.Entity<Payments>()
                .Property(e => e.paymentAmount)
                .IsUnicode(false);

            modelBuilder.Entity<Producers>()
                .Property(e => e.pdcPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Producers>()
                .Property(e => e.pdcEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.proID)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.proSize)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.proPrice)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.proUpdateDate)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Products)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Products>()
                .HasOptional(e => e.Rates)
                .WithRequired(e => e.Products);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.ShoppingCartItems)
                .WithRequired(e => e.Products)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rates>()
                .Property(e => e.proID)
                .IsUnicode(false);

            modelBuilder.Entity<ShippingDetails>()
                .Property(e => e.orderID)
                .IsUnicode(false);

            modelBuilder.Entity<ShoppingCartItems>()
                .Property(e => e.cusPhone)
                .IsUnicode(false);

            modelBuilder.Entity<ShoppingCartItems>()
                .Property(e => e.proID)
                .IsUnicode(false);

            modelBuilder.Entity<ShoppingCartItems>()
                .Property(e => e.price)
                .IsUnicode(false);
        }
    }
}
