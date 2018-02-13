using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MOBILESHOPFLOW.Models;

namespace MOBILESHOPFLOW.Models
{
    public partial class dbMobileShopContext : DbContext
    {
        public virtual DbSet<TblCatagories> TblCatagories { get; set; }
        public virtual DbSet<TblCustomer> TblCustomer { get; set; }
        public virtual DbSet<TblItem> TblItem { get; set; }
        public virtual DbSet<TblPurchase> TblPurchase { get; set; }
        public virtual DbSet<TblSales> TblSales { get; set; }
        public virtual DbSet<TblVendor> TblVendor { get; set; }

        public dbMobileShopContext(DbContextOptions<dbMobileShopContext> msf):base(msf)
        {
            //HERE IS CONSTRUCTOR FOR ORM
        }
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=HASSAN_NAWAZ;Database=dbMobileShop;Trusted_Connection=True;User ID=masoom; Password=masoom;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<TblCatagories>(entity =>
            {
                entity.HasKey(e => e.CatagoryId);

                entity.ToTable("tblCatagories");

                entity.Property(e => e.CatagoryId)
                    .HasColumnName("Catagory_id");
                   

                entity.Property(e => e.CatagoryName)
                    .HasColumnName("Catagory_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.HasKey(e => e.Cusotmer_id);

                entity.ToTable("tblCustomer");

                entity.Property(e => e.Cusotmer_id)
                    .HasColumnName("Cusotmer_id");
                   

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblItem>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("tblItem");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id");
                   

                entity.Property(e => e.CatagoryId).HasColumnName("Catagory_id");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Discription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasColumnName("Model#")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPurchase>(entity =>
            {
                entity.HasKey(e => e.PurchaseId);

                entity.ToTable("tblPurchase");

                entity.Property(e => e.PurchaseId)
                    .HasColumnName("Purchase_id");
                   

                entity.Property(e => e.CatagoryId).HasColumnName("Catagory_id");

                entity.Property(e => e.VendorId).HasColumnName("Vendor_id");
            });

            modelBuilder.Entity<TblSales>(entity =>
            {
                entity.HasKey(e => e.SaleId);

                entity.ToTable("tblSales");

                entity.Property(e => e.SaleId)
                    .HasColumnName("Sale_id");
                   

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.ItemId).HasColumnName("item_id");
            });

           
            modelBuilder.Entity<TblVendor>(entity =>
            {
                entity.HasKey(e => e.VendorId);
                entity.Property(p => p.VendorId);
                
                
                entity.ToTable("tblVendor");

                entity.Property(e => e.VendorId)
                    .HasColumnName("Vendor_id").UseSqlServerIdentityColumn();



                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=HASSAN_NAWAZ;Database=dbMobileShop;Trusted_Connection=True;User ID=masoom; Password=masoom;");
//            }
//        }

        public DbSet<MOBILESHOPFLOW.Models.tblUser> tblUser { get; set; }
    }
}
