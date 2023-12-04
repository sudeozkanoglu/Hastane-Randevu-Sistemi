using Microsoft.EntityFrameworkCore;
using webProjeOdev.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace webProjeOdev.Data
{
    public class HastaneRandevuContext : DbContext
    {
        public DbSet<AnaBilimDali> AnaBilimDallari { get; set; }
        public DbSet<Doktor>Doktorlar { get; set; }
        public DbSet<Hasta> Hastalar { get; set; }
        public DbSet<Hastane> Hastaneler { get; set; }
        public DbSet<IletisimBilgileri> IletisimBilgileri { get; set; }
        public DbSet<Klinik> Klinikler { get; set; }
        public DbSet<Poliklinik> Poliklinikler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=randevuSistemi; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doktor>()
                .Property(a => a.calismaSaat)
                .HasColumnType("time");

            //*******************************************************************
            //Klinik tablosunda yer alan collectionlar
            modelBuilder.Entity<Klinik>()
                .HasMany(e => e.Doktorlar)
                .WithOne(e => e.Klinik)
                .HasForeignKey(e => e.klinikId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<Klinik>()
                .HasMany(s => s.Poliklinikler)
                .WithOne(s => s.Klinik)
                .HasForeignKey(e => e.klinikId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            //**************************************************
            //AnaBilimDali tabsolunda yer alan Collectionlar
            modelBuilder.Entity<AnaBilimDali>()
                .HasMany(u => u.Doktorlar)
                .WithOne(u => u.AnaBilimDali)
                .HasForeignKey(u => u.anaBilimDaliId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<AnaBilimDali>()
                .HasMany(f => f.Klinikler)
                .WithOne(f => f.AnaBilimDali)
                .HasForeignKey(f => f.anaBilimDaliId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            //**************************************************
            //Doktor tabsolunda yer alan Collectionlar
            modelBuilder.Entity<Doktor>()
                .HasMany(a => a.IletisimBilgileri)
                .WithOne(a => a.Doktor)
                .HasForeignKey(a => a.doktorId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<Doktor>()
                .HasMany(z => z.Poliklinikler)
                .WithOne(z => z.Doktor)
                .HasForeignKey(z => z.doktorId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            //**************************************************
            //Hasta tabsolunda yer alan Collectionlar
            modelBuilder.Entity<Hasta>()
                .HasMany(b => b.IletisimBilgileri)
                .WithOne(b => b.Hasta)
                .HasForeignKey(b => b.hastaId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            //**************************************************
            //Hastane tabsolunda yer alan Collectionlar
            modelBuilder.Entity<Hastane>()
                .HasMany(c => c.IletisimBilgileri)
                .WithOne(c => c.Hastane)
                .HasForeignKey(c => c.hastaneId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<Hastane>()
                .HasMany(d => d.Doktorlar)
                .WithOne(d => d.Hastane)
                .HasForeignKey(d => d.hastaneId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            //**************************************************

        }
    }
}
