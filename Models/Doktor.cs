﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webProjeOdev.Data.Enum;

namespace webProjeOdev.Models
{
    public class Doktor
    {
        [Key]
        public int doktorId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="Doktor Adı")]
        public string doktorAdi { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Doktor Soyadı")]
        public string doktorSoyadi { get; set; }

        [Required]
        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dogumTarihi { get; set; }

        [Required]
        [Display(Name = "Cinsiyet")]
        public Cinsiyet cinsiyet { get; set; }

        public enum Cinsiyet
        {
            Kadın,
            Erkek
        }

        [Required]
        [Display(Name = "Medeni Hal")]
        public MedeniHal medeniHal { get; set; }

        public enum MedeniHal
        {
            Evli,
            Bekar
        }

        [Required]
        [Display(Name = "Çalışma Günleri")]
        public CalismaGunleri calismaGunleri { get; set; }

        [Required]
        [Column(TypeName = "time")]
        [Display(Name = "Çalışma Saatleri")]
        public TimeSpan calismaSaat { get; set; }

        [Required]
        [Display(Name ="Ana Bilim Dalı")]
        public string brans { get; set; }

        [Required]
        [Display(Name ="Klinik Adı")]
        public string doktorKlinik { get; set; }

        [Required]
        [Display(Name ="Poliklinik")]
        public string doktorPoliklinik { get; set; }

        //***************************************************************

        [ForeignKey("AnaBilimDali")]
        public int anaBilimDaliId { get; set; }
        public AnaBilimDali AnaBilimDali { get; set; } = null!;

        [ForeignKey("Klinik")]
        public int klinikId { get; set; }
        public Klinik Klinik { get; set; } = null!;

        [ForeignKey("Hastane")]
        public int hastaneId { get; set; }
        public Hastane Hastane { get; set; } = null!;

        //****************************************************************
        public ICollection<IletisimBilgileri> IletisimBilgileri { get; set; }
        public ICollection<Poliklinik> Poliklinikler { get; set; }

    }
}