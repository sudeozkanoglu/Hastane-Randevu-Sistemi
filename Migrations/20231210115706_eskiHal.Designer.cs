﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebProjeOdev2.Data;

#nullable disable

namespace webProjeOdev2.Migrations
{
    [DbContext(typeof(HastaneRandevuContext))]
    [Migration("20231210115706_eskiHal")]
    partial class eskiHal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("webProjeOdev2.Models.AnaBilimDali", b =>
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

            modelBuilder.Entity("webProjeOdev2.Models.Doktor", b =>
                {
                    b.Property<int>("doktorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("doktorId"));

                    b.Property<int>("Iller")
                        .HasColumnType("int");

                    b.Property<int>("anaBilimDaliId")
                        .HasColumnType("int");

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

                    b.Property<string>("doktorSoyadi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("hastaneId")
                        .HasColumnType("int");

                    b.Property<int>("klinikId")
                        .HasColumnType("int");

                    b.Property<int>("medeniHal")
                        .HasColumnType("int");

                    b.Property<string>("telefonNumarasi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("doktorId");

                    b.HasIndex("anaBilimDaliId");

                    b.HasIndex("hastaneId");

                    b.HasIndex("klinikId");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("webProjeOdev2.Models.Hasta", b =>
                {
                    b.Property<int>("hastaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("hastaId"));

                    b.Property<int>("Iller")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("cinsiyet")
                        .HasColumnType("int");

                    b.Property<DateTime>("dogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hastaAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("hastaSifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("telefonNumarasi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("hastaId");

                    b.ToTable("Hastalar");
                });

            modelBuilder.Entity("webProjeOdev2.Models.Hastane", b =>
                {
                    b.Property<int>("hastaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("hastaneId"));

                    b.Property<int>("Iller")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hastaneAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("telefonNumarasi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("hastaneId");

                    b.ToTable("Hastaneler");
                });

            modelBuilder.Entity("webProjeOdev2.Models.HastaneAnaBilim", b =>
                {
                    b.Property<int>("anaBilimDaliId")
                        .HasColumnType("int");

                    b.Property<int>("hastaneId")
                        .HasColumnType("int");

                    b.HasKey("anaBilimDaliId", "hastaneId");

                    b.HasIndex("hastaneId");

                    b.ToTable("HastaneAnaBilim");
                });

            modelBuilder.Entity("webProjeOdev2.Models.HastaneHasta", b =>
                {
                    b.Property<int>("hastaId")
                        .HasColumnType("int");

                    b.Property<int>("hastaneId")
                        .HasColumnType("int");

                    b.HasKey("hastaId", "hastaneId");

                    b.HasIndex("hastaneId");

                    b.ToTable("HastaneHasta");
                });

            modelBuilder.Entity("webProjeOdev2.Models.HastaneKlinik", b =>
                {
                    b.Property<int>("hastaneId")
                        .HasColumnType("int");

                    b.Property<int>("klinikId")
                        .HasColumnType("int");

                    b.Property<int>("poliklinikId")
                        .HasColumnType("int");

                    b.HasKey("hastaneId", "klinikId");

                    b.HasIndex("klinikId");

                    b.HasIndex("poliklinikId");

                    b.ToTable("HastaneKlinik");
                });

            modelBuilder.Entity("webProjeOdev2.Models.HastanePoliklinik", b =>
                {
                    b.Property<int>("hastaneId")
                        .HasColumnType("int");

                    b.Property<int>("poliklinikId")
                        .HasColumnType("int");

                    b.HasKey("hastaneId", "poliklinikId");

                    b.HasIndex("poliklinikId");

                    b.ToTable("HastanePoliklinik");
                });

            modelBuilder.Entity("webProjeOdev2.Models.Klinik", b =>
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

            modelBuilder.Entity("webProjeOdev2.Models.Poliklinik", b =>
                {
                    b.Property<int>("poliklinikId")
                        .HasColumnType("int");

                    b.Property<int>("klinikId")
                        .HasColumnType("int");

                    b.Property<string>("poliklinikAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("poliklinikId");

                    b.HasIndex("klinikId");

                    b.ToTable("Poliklinikler");
                });

            modelBuilder.Entity("webProjeOdev2.Models.Randevu", b =>
                {
                    b.Property<int>("randevuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("randevuId"));

                    b.Property<int>("anaBilimDaliId")
                        .HasColumnType("int");

                    b.Property<int>("doktorId")
                        .HasColumnType("int");

                    b.Property<int>("hastaId")
                        .HasColumnType("int");

                    b.Property<int>("hastaneId")
                        .HasColumnType("int");

                    b.Property<int>("klinikId")
                        .HasColumnType("int");

                    b.Property<int>("poliklinikId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("randevuSaat")
                        .HasColumnType("time");

                    b.Property<DateTime>("randevuTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("randevuId");

                    b.HasIndex("anaBilimDaliId");

                    b.HasIndex("doktorId");

                    b.HasIndex("hastaId");

                    b.HasIndex("hastaneId");

                    b.HasIndex("klinikId");

                    b.HasIndex("poliklinikId");

                    b.ToTable("Randevular");
                });

            modelBuilder.Entity("webProjeOdev2.Models.Doktor", b =>
                {
                    b.HasOne("webProjeOdev2.Models.AnaBilimDali", "AnaBilimDali")
                        .WithMany("Doktorlar")
                        .HasForeignKey("anaBilimDaliId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("webProjeOdev2.Models.Hastane", "Hastane")
                        .WithMany("Doktorlar")
                        .HasForeignKey("hastaneId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("webProjeOdev2.Models.Klinik", "Klinik")
                        .WithMany("Doktorlar")
                        .HasForeignKey("klinikId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AnaBilimDali");

                    b.Navigation("Hastane");

                    b.Navigation("Klinik");
                });

            modelBuilder.Entity("webProjeOdev2.Models.HastaneAnaBilim", b =>
                {
                    b.HasOne("webProjeOdev2.Models.AnaBilimDali", "AnaBilimDali")
                        .WithMany("HastaneAnaBilimler")
                        .HasForeignKey("anaBilimDaliId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webProjeOdev2.Models.Hastane", "Hastane")
                        .WithMany("HastaneAnaBilimler")
                        .HasForeignKey("hastaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnaBilimDali");

                    b.Navigation("Hastane");
                });

            modelBuilder.Entity("webProjeOdev2.Models.HastaneHasta", b =>
                {
                    b.HasOne("webProjeOdev2.Models.Hasta", "Hasta")
                        .WithMany("HastaneHastalar")
                        .HasForeignKey("hastaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webProjeOdev2.Models.Hastane", "Hastane")
                        .WithMany("HastaneHastalar")
                        .HasForeignKey("hastaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hasta");

                    b.Navigation("Hastane");
                });

            modelBuilder.Entity("webProjeOdev2.Models.HastaneKlinik", b =>
                {
                    b.HasOne("webProjeOdev2.Models.Hastane", "Hastane")
                        .WithMany("HastaneKlinikler")
                        .HasForeignKey("hastaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webProjeOdev2.Models.Klinik", "Klinik")
                        .WithMany("HastaneKlinikler")
                        .HasForeignKey("klinikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webProjeOdev2.Models.Poliklinik", null)
                        .WithMany("HastaneKlinikler")
                        .HasForeignKey("poliklinikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hastane");

                    b.Navigation("Klinik");
                });

            modelBuilder.Entity("webProjeOdev2.Models.HastanePoliklinik", b =>
                {
                    b.HasOne("webProjeOdev2.Models.Hastane", "Hastane")
                        .WithMany("HastanePoliklinikler")
                        .HasForeignKey("hastaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webProjeOdev2.Models.Poliklinik", "Poliklinik")
                        .WithMany()
                        .HasForeignKey("poliklinikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hastane");

                    b.Navigation("Poliklinik");
                });

            modelBuilder.Entity("webProjeOdev2.Models.Klinik", b =>
                {
                    b.HasOne("webProjeOdev2.Models.AnaBilimDali", "AnaBilimDali")
                        .WithMany("Klinikler")
                        .HasForeignKey("anaBilimDaliId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AnaBilimDali");
                });

            modelBuilder.Entity("webProjeOdev2.Models.Poliklinik", b =>
                {
                    b.HasOne("webProjeOdev2.Models.Klinik", "Klinik")
                        .WithMany("Poliklinikler")
                        .HasForeignKey("klinikId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("webProjeOdev2.Models.Doktor", "Doktor")
                        .WithOne("Poliklinik")
                        .HasForeignKey("webProjeOdev2.Models.Poliklinik", "poliklinikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doktor");

                    b.Navigation("Klinik");
                });

            modelBuilder.Entity("webProjeOdev2.Models.Randevu", b =>
                {
                    b.HasOne("webProjeOdev2.Models.AnaBilimDali", "AnaBilimDali")
                        .WithMany("Randevular")
                        .HasForeignKey("anaBilimDaliId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("webProjeOdev2.Models.Doktor", "Doktor")
                        .WithMany("Randevular")
                        .HasForeignKey("doktorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("webProjeOdev2.Models.Hasta", "Hasta")
                        .WithMany("Randevular")
                        .HasForeignKey("hastaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("webProjeOdev2.Models.Hastane", "Hastane")
                        .WithMany("Randevular")
                        .HasForeignKey("hastaneId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("webProjeOdev2.Models.Klinik", "Klinik")
                        .WithMany("Randevular")
                        .HasForeignKey("klinikId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("webProjeOdev2.Models.Poliklinik", "Poliklinik")
                        .WithMany("Randevular")
                        .HasForeignKey("poliklinikId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AnaBilimDali");

                    b.Navigation("Doktor");

                    b.Navigation("Hasta");

                    b.Navigation("Hastane");

                    b.Navigation("Klinik");

                    b.Navigation("Poliklinik");
                });

            modelBuilder.Entity("webProjeOdev2.Models.AnaBilimDali", b =>
                {
                    b.Navigation("Doktorlar");

                    b.Navigation("HastaneAnaBilimler");

                    b.Navigation("Klinikler");

                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("webProjeOdev2.Models.Doktor", b =>
                {
                    b.Navigation("Poliklinik")
                        .IsRequired();

                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("webProjeOdev2.Models.Hasta", b =>
                {
                    b.Navigation("HastaneHastalar");

                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("webProjeOdev2.Models.Hastane", b =>
                {
                    b.Navigation("Doktorlar");

                    b.Navigation("HastaneAnaBilimler");

                    b.Navigation("HastaneHastalar");

                    b.Navigation("HastaneKlinikler");

                    b.Navigation("HastanePoliklinikler");

                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("webProjeOdev2.Models.Klinik", b =>
                {
                    b.Navigation("Doktorlar");

                    b.Navigation("HastaneKlinikler");

                    b.Navigation("Poliklinikler");

                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("webProjeOdev2.Models.Poliklinik", b =>
                {
                    b.Navigation("HastaneKlinikler");

                    b.Navigation("Randevular");
                });
#pragma warning restore 612, 618
        }
    }
}
