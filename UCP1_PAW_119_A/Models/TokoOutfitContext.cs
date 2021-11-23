using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_119_A.Models
{
    public partial class TokoOutfitContext : DbContext
    {
        public TokoOutfitContext()
        {
        }

        public TokoOutfitContext(DbContextOptions<TokoOutfitContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Customer1> Customer1s { get; set; }
        public virtual DbSet<Outfit> Outfits { get; set; }
        public virtual DbSet<Transaksi> Transaksis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.ToTable("Admin");

                entity.Property(e => e.IdAdmin)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Admin");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nama)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NoTelp)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("No_Telp");
            });

            modelBuilder.Entity<Customer1>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.ToTable("Customer1");

                entity.Property(e => e.IdCustomer)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Customer");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nama)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NoTelp)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("No_Telp");
            });

            modelBuilder.Entity<Outfit>(entity =>
            {
                entity.HasKey(e => e.IdOutfit);

                entity.ToTable("Outfit");

                entity.Property(e => e.IdOutfit)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Outfit");

                entity.Property(e => e.NamaOutfit)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Outfit");

                entity.Property(e => e.Perusahaan)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi);

                entity.ToTable("Transaksi");

                entity.Property(e => e.IdTransaksi)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Transaksi");

                entity.Property(e => e.IdAdmin).HasColumnName("ID_Admin");

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.IdOutfit).HasColumnName("ID_Outfit");

                entity.Property(e => e.Total)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdAdmin)
                    .HasConstraintName("FK_Transaksi_Admin");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_Transaksi_Customer1");

                entity.HasOne(d => d.IdOutfitNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdOutfit)
                    .HasConstraintName("FK_Transaksi_Outfit");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
