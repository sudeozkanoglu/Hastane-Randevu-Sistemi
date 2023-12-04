﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webProjeOdev.Data;

#nullable disable

namespace webProjeOdev.Migrations
{
    [DbContext(typeof(HastaneRandevuContext))]
    partial class HastaneRandevuContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("webProjeOdev.Models.AnaBilimDali", b =>
                {
                    b.Property<int>("anaBilimDaliId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("anaBilimDaliId"));

                    b.Property<string>("anaBilimDaliAdi")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("anaBilimDaliId");

                    b.ToTable("AnaBilimDallari");
                });

            modelBuilder.Entity("webProjeOdev.Models.Doktor", b =>
                {
                    b.Property<int>("doktorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("doktorId"));

                    b.Property<int>("anaBilimDaliId")
                        .HasColumnType("int");

                    b.Property<string>("brans")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("calismaGunleri")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("calismaSaat")
                        .HasColumnType("time");

                    b.Property<int>("cinsiyet")
                        .HasColumnType("int");

                    b.Property<DateTime>("dogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("doktorAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("doktorKlinik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("doktorPoliklinik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("doktorSoyadi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("hastaneId")
                        .HasColumnType("int");

                    b.Property<int>("klinikId")
                        .HasColumnType("int");

                    b.Property<int>("medeniHal")
                        .HasColumnType("int");

                    b.HasKey("doktorId");

                    b.HasIndex("anaBilimDaliId");

                    b.HasIndex("hastaneId");

                    b.HasIndex("klinikId");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("webProjeOdev.Models.Hasta", b =>
                {
                    b.Property<int>("hastaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("hastaId"));

                    b.Property<int>("cinsiyet")
                        .HasColumnType("int");

                    b.Property<DateTime>("dogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("hastaAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("hastaSoyadi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("hastaTC")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("medeniHal")
                        .HasColumnType("int");

                    b.HasKey("hastaId");

                    b.ToTable("Hastalar");
                });

            modelBuilder.Entity("webProjeOdev.Models.Hastane", b =>
                {
                    b.Property<int>("hastaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("hastaneId"));

                    b.Property<string>("anaBilimDaliAdi")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("hastaneAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("klinikAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("poliklinikAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("hastaneId");

                    b.ToTable("Hastaneler");
                });

            modelBuilder.Entity("webProjeOdev.Models.IletisimBilgileri", b =>
                {
                    b.Property<int>("iletisimId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("iletisimId"));

                    b.Property<int>("Iller")
                        .HasColumnType("int");

                    b.Property<int>("doktorId")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("hastaId")
                        .HasColumnType("int");

                    b.Property<int>("hastaneId")
                        .HasColumnType("int");

                    b.Property<string>("telefonNumarasi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("iletisimId");

                    b.HasIndex("doktorId");

                    b.HasIndex("hastaId");

                    b.HasIndex("hastaneId");

                    b.ToTable("IletisimBilgileri");
                });

            modelBuilder.Entity("webProjeOdev.Models.Klinik", b =>
                {
                    b.Property<int>("klinikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("klinikId"));

                    b.Property<int>("anaBilimDaliId")
                        .HasColumnType("int");

                    b.Property<string>("klinikAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("klinikId");

                    b.HasIndex("anaBilimDaliId");

                    b.ToTable("Klinikler");
                });

            modelBuilder.Entity("webProjeOdev.Models.Poliklinik", b =>
                {
                    b.Property<int>("poliklinikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("poliklinikId"));

                    b.Property<int>("doktorId")
                        .HasColumnType("int");

                    b.Property<int>("klinikId")
                        .HasColumnType("int");

                    b.Property<string>("poliklinikAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("poliklinikId");

                    b.HasIndex("doktorId");

                    b.HasIndex("klinikId");

                    b.ToTable("Poliklinikler");
                });

            modelBuilder.Entity("webProjeOdev.Models.Doktor", b =>
                {
                    b.HasOne("webProjeOdev.Models.AnaBilimDali", "AnaBilimDali")
                        .WithMany("Doktorlar")
                        .HasForeignKey("anaBilimDaliId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("webProjeOdev.Models.Hastane", "Hastane")
                        .WithMany("Doktorlar")
                        .HasForeignKey("hastaneId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("webProjeOdev.Models.Klinik", "Klinik")
                        .WithMany("Doktorlar")
                        .HasForeignKey("klinikId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AnaBilimDali");

                    b.Navigation("Hastane");

                    b.Navigation("Klinik");
                });

            modelBuilder.Entity("webProjeOdev.Models.IletisimBilgileri", b =>
                {
                    b.HasOne("webProjeOdev.Models.Doktor", "Doktor")
                        .WithMany("IletisimBilgileri")
                        .HasForeignKey("doktorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("webProjeOdev.Models.Hasta", "Hasta")
                        .WithMany("IletisimBilgileri")
                        .HasForeignKey("hastaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("webProjeOdev.Models.Hastane", "Hastane")
                        .WithMany("IletisimBilgileri")
                        .HasForeignKey("hastaneId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Doktor");

                    b.Navigation("Hasta");

                    b.Navigation("Hastane");
                });

            modelBuilder.Entity("webProjeOdev.Models.Klinik", b =>
                {
                    b.HasOne("webProjeOdev.Models.AnaBilimDali", "AnaBilimDali")
                        .WithMany("Klinikler")
                        .HasForeignKey("anaBilimDaliId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AnaBilimDali");
                });

            modelBuilder.Entity("webProjeOdev.Models.Poliklinik", b =>
                {
                    b.HasOne("webProjeOdev.Models.Doktor", "Doktor")
                        .WithMany("Poliklinikler")
                        .HasForeignKey("doktorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("webProjeOdev.Models.Klinik", "Klinik")
                        .WithMany("Poliklinikler")
                        .HasForeignKey("klinikId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Doktor");

                    b.Navigation("Klinik");
                });

            modelBuilder.Entity("webProjeOdev.Models.AnaBilimDali", b =>
                {
                    b.Navigation("Doktorlar");

                    b.Navigation("Klinikler");
                });

            modelBuilder.Entity("webProjeOdev.Models.Doktor", b =>
                {
                    b.Navigation("IletisimBilgileri");

                    b.Navigation("Poliklinikler");
                });

            modelBuilder.Entity("webProjeOdev.Models.Hasta", b =>
                {
                    b.Navigation("IletisimBilgileri");
                });

            modelBuilder.Entity("webProjeOdev.Models.Hastane", b =>
                {
                    b.Navigation("Doktorlar");

                    b.Navigation("IletisimBilgileri");
                });

            modelBuilder.Entity("webProjeOdev.Models.Klinik", b =>
                {
                    b.Navigation("Doktorlar");

                    b.Navigation("Poliklinikler");
                });
#pragma warning restore 612, 618
        }
    }
}
