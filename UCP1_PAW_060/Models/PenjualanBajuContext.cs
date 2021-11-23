using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UCP1_PAW_060.Models
{
    public partial class PenjualanBajuContext : DbContext
    {
        public PenjualanBajuContext()
        {
        }

        public PenjualanBajuContext(DbContextOptions<PenjualanBajuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Baju> Baju { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Pembeli> Pembeli { get; set; }
        public virtual DbSet<Sistem> Sistem { get; set; }
        public virtual DbSet<Transaksi> Transaksi { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdPenjual);

                entity.Property(e => e.IdPenjual)
                    .HasColumnName("idPenjual")
                    .ValueGeneratedNever();

                entity.Property(e => e.NoTelepon)
                    .HasColumnName("noTelepon")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Baju>(entity =>
            {
                entity.HasKey(e => e.IdBaju);

                entity.Property(e => e.IdBaju)
                    .HasColumnName("idBaju")
                    .ValueGeneratedNever();

                entity.Property(e => e.HargaBaju)
                    .HasColumnName("hargaBaju")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StokBaju)
                    .HasColumnName("stokBaju")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.IdLogin);

                entity.Property(e => e.IdLogin)
                    .HasColumnName("idLogin")
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pembeli>(entity =>
            {
                entity.HasKey(e => e.IdPembeli);

                entity.Property(e => e.IdPembeli)
                    .HasColumnName("idPembeli")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alamat)
                    .HasColumnName("alamat")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoTelepon)
                    .HasColumnName("noTelepon")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sistem>(entity =>
            {
                entity.HasKey(e => e.IdBaju);

                entity.Property(e => e.IdBaju)
                    .HasColumnName("idBaju")
                    .ValueGeneratedNever();

                entity.Property(e => e.Harga)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamaBaju)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi);

                entity.Property(e => e.IdTransaksi)
                    .HasColumnName("idTransaksi")
                    .ValueGeneratedNever();

                entity.Property(e => e.HargaBaju)
                    .HasColumnName("hargaBaju")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdPembeli).HasColumnName("idPembeli");

                entity.Property(e => e.IdPenjual).HasColumnName("idPenjual");

                entity.Property(e => e.JumlahBaju)
                    .HasColumnName("jumlahBaju")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KodeBaju)
                    .HasColumnName("kodeBaju")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TanggalTransaksi).HasColumnType("datetime");

                entity.Property(e => e.TotalBaju)
                    .HasColumnName("totalBaju")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
