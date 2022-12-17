using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev3_API.Models
{
    public class ObsDbContext : DbContext
    {
        public ObsDbContext(DbContextOptions<ObsDbContext> options) : base(options) { }
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Akademisyen> Akademisyenler { get; set; }
        public DbSet<Ders> Dersler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {/*Fluent Api kullanımı:*/
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ogrenci>().ToTable("Öğrenci");
            modelBuilder.Entity<Ogrenci>().HasKey(key => key.OgrenciNo).HasName("Öğrenci No");
            modelBuilder.Entity<Ogrenci>().Property(p => p.OgrenciAd).HasColumnName("İsim").HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(p => p.OgrenciSoyad).HasColumnName("Soyisim").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(p => p.OgrenciTC).HasColumnName("T.C. Kimlik No").HasColumnType("bigint").HasMaxLength(11).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(p => p.DogumTarihi).HasColumnName("Doğum Tarihi").HasColumnType("date").IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(p => p.Telefon).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(p => p.EPosta).HasMaxLength(50);
            //modelBuilder.Entity<Ogrenci>().Property(p => p.Adres).HasColumnType("text").HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(p => p.Bolum).HasColumnName("Bölüm").HasMaxLength(25).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(p => p.Sinif).HasColumnName("Sınıf").IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(p => p.AktifMi).IsRequired();


            modelBuilder.Entity<Akademisyen>().Property(p => p.Unvan).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Akademisyen>().Property(p => p.AkademisyenAd).HasColumnName("İsim").HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Akademisyen>().Property(p => p.AkademisyenSoyad).HasColumnName("Soyisim").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Akademisyen>().Property(p => p.AkademisyenTC).HasColumnName("T.C. Kimlik No").HasColumnType("bigint").HasMaxLength(11).IsRequired();
            modelBuilder.Entity<Akademisyen>().Property(p => p.DogumTarihi).HasColumnName("Doğum Tarihi").HasColumnType("date").IsRequired();
            modelBuilder.Entity<Akademisyen>().Property(p => p.Telefon).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Akademisyen>().Property(p => p.EPosta).HasMaxLength(50);
            //modelBuilder.Entity<Akademisyen>().Property(p => p.Adres).HasColumnType("text").HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Akademisyen>().Property(p => p.AnabilimDali).HasColumnName("Anabilim Dalı").HasMaxLength(25).IsRequired();
            modelBuilder.Entity<Akademisyen>().Property(p => p.AktifMi).IsRequired();


            modelBuilder.Entity<Ders>().Property(p => p.DersKodu).HasColumnName("Ders Kodu").HasMaxLength(25).IsRequired();
            modelBuilder.Entity<Ders>().Property(p => p.DersAdi).HasColumnName("Ders Adı").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ders>().Property(p => p.KacSaat).HasColumnName("Ders Saati").IsRequired();
            modelBuilder.Entity<Ders>().Property(p => p.Kredi).IsRequired();
            modelBuilder.Entity<Ders>().Property(p => p.Donem).HasColumnName("Dönem").IsRequired();
            //modelBuilder.Entity<Ders>().Property(p => p.Dili).HasColumnName("Ders Dili").HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Ders>().Property(p => p.Derslik).HasColumnType("text").HasMaxLength(10);
            modelBuilder.Entity<Ders>().Property(p => p.Aciklama).HasColumnName("Açıklama").HasColumnType("text").HasMaxLength(25);
            modelBuilder.Entity<Ogrenci>().Property(p => p.AktifMi).IsRequired();
            modelBuilder.Entity<Ders>().Property(p => p.AkademisyenId).IsRequired();
        }
    }
}
