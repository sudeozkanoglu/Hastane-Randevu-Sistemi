using Microsoft.EntityFrameworkCore;
using webProjeOdev.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using Microsoft.Extensions.Hosting;

namespace webProjeOdev.Data
{
    public class HastaneRandevuContext : DbContext
    {
        public DbSet<AnaBilimDali> AnaBilimDallari { get; set; }
        public DbSet<Doktor>Doktorlar { get; set; }
        public DbSet<Hasta> Hastalar { get; set; }
        public DbSet<Hastane> Hastaneler { get; set; }
        public DbSet<Klinik> Klinikler { get; set; }
        public DbSet<Poliklinik> Poliklinikler { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<HastaneKlinik> HastaneKlinikler { get; set; }
        public DbSet<HastanePoliklinik> HastanePoliklinikler { get; set; }
        public DbSet<HastaneAnaBilim> HastaneAnaBilimler { get; set; }
        public DbSet<HastaneHasta> HastaneHastalar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=yedekRandevuSistemi; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doktor>()
                .Property(a => a.calismaSaat)
                .HasColumnType("time");

            modelBuilder.Entity<Randevu>()
                .Property(a => a.randevuSaat)
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

            modelBuilder.Entity<Klinik>()
                .HasMany(y => y.Randevular)
                .WithOne(y => y.Klinik)
                .HasForeignKey(y => y.klinikId)
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

            modelBuilder.Entity<AnaBilimDali>()
                .HasMany(f => f.Randevular)
                .WithOne(f => f.AnaBilimDali)
                .HasForeignKey(f => f.anaBilimDaliId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            //**************************************************
            //Doktor tabsolunda yer alan Collectionlar

            modelBuilder.Entity<Doktor>()
                .HasMany(z => z.Randevular)
                .WithOne(z => z.Doktor)
                .HasForeignKey(z => z.doktorId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            //**************************************************
            //Hasta tabsolunda yer alan Collectionlar
            modelBuilder.Entity<Hasta>()
                .HasMany(b => b.Randevular)
                .WithOne(b => b.Hasta)
                .HasForeignKey(b => b.hastaId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            //**************************************************
            //Hastane tabsolunda yer alan Collectionlar

            modelBuilder.Entity<Hastane>()
                .HasMany(d => d.Doktorlar)
                .WithOne(d => d.Hastane)
                .HasForeignKey(d => d.hastaneId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<Hastane>()
                .HasMany(p => p.Randevular)
                .WithOne(p => p.Hastane)
                .HasForeignKey(p => p.hastaneId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            //**************************************************
            //Poliklinik tabsolunda yer alan Collectionlar
            modelBuilder.Entity<Poliklinik>()
                .HasMany(c => c.Randevular)
                .WithOne(c => c.Poliklinik)
                .HasForeignKey(c => c.poliklinikId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            
            //**************************************************
            //Çok a çok ilişki kısmı
            //HastaneHasta
            modelBuilder.Entity<Hasta>()
                .HasMany(k => k.Hastaneler)
                .WithMany(k => k.Hastalar)
                .UsingEntity<HastaneHasta>();

            modelBuilder.Entity<Hastane>()
                .HasMany(l => l.Hastalar)
                .WithMany(l => l.Hastaneler)
                .UsingEntity<HastaneHasta>();

            //**************************************************
            //Çok a çok ilişki kısmı
            //HastaneAnaBilim
            modelBuilder.Entity<AnaBilimDali>()
                .HasMany(t => t.Hastaneler)
                .WithMany(t => t.AnaBilimDallari)
                .UsingEntity<HastaneAnaBilim>();

            modelBuilder.Entity<Hastane>()
                .HasMany(o => o.AnaBilimDallari)
                .WithMany(o => o.Hastaneler)
                .UsingEntity<HastaneAnaBilim>();
            //**************************************************
            //Çok a çok ilişki kısmı
            //HastaneKlinik
           modelBuilder.Entity<Klinik>()
                .HasMany(sa => sa.Hastaneler)
                .WithMany(sa => sa.Klinikler)
                .UsingEntity<HastaneKlinik>();

            modelBuilder.Entity<Hastane>()
                .HasMany(sd => sd.Klinikler)
                .WithMany(sd => sd.Hastaneler)
                .UsingEntity<HastaneKlinik>();
            //**************************************************
            //Çok a çok ilişki kısmı
            //HastanePoliklinik
            modelBuilder.Entity<Poliklinik>()
                .HasMany(sf => sf.Hastaneler)
                .WithMany(sf => sf.Poliklinikler)
                .UsingEntity<HastanePoliklinik>();

            modelBuilder.Entity<Hastane>()
                .HasMany(sh => sh.Poliklinikler)
                .WithMany(sh => sh.Hastaneler)
                .UsingEntity<HastanePoliklinik>();
            
            //**************************************************
            modelBuilder.Entity<Poliklinik>()
                .HasOne(ax => ax.Doktor)
                .WithOne(ax => ax.Poliklinik)
                .HasForeignKey<Doktor>(ax => ax.doktorId);
        }
    }
}
