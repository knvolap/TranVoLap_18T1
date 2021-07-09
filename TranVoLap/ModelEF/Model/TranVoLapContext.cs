using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ModelEF.Model
{
    public partial class TranVoLapContext : DbContext
    {
        public TranVoLapContext()
            : base("name=TranVoLapContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<UserOder> UserOders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.IDCategory)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Category)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Product>()
                .Property(e => e.IDProduct)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.IDCategory)
                .IsUnicode(false);

            //modelBuilder.Entity<Product>()
            //    .Property(e => e.MetaName)
            //    .IsUnicode(false).IsRequired();

            //modelBuilder.Entity<Product>()
            //    .Property(e => e.Image)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Product>()
            //    .Property(e => e.Author)
            //    .IsUnicode(false).IsRequired();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.UserOders)
                .WithOptional(e => e.Product)
                .WillCascadeOnDelete();

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.IDUser)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.UserName)
                .IsUnicode(false);


            modelBuilder.Entity<UserAccount>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.UserType)
                .IsUnicode(false);

            modelBuilder.Entity<UserOder>()
                .Property(e => e.IDOder)
                .IsUnicode(false);

            modelBuilder.Entity<UserOder>()
                .Property(e => e.IDProduct)
                .IsUnicode(false);

            modelBuilder.Entity<UserOder>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
