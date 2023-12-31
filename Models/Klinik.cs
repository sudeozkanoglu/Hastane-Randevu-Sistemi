﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webProjeOdev8.Models
{
    public class Klinik
    {

        [Key]
        public int klinikId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Klinik Adı")]
        public string klinikAdi { get; set; }

        //*******************************************************

        [ForeignKey("AnaBilimDali")]
        public int anaBilimDaliId { get; set; }
        public AnaBilimDali AnaBilimDali { get; set; } = null!;

        //**********************************************************

        public ICollection<Doktor> Doktorlar { get; set; }
        public ICollection<Poliklinik> Poliklinikler { get; set; }
        public ICollection<Randevu> Randevular { get; set; }

        //********************************************************
        //Çok a çok ilişki kısmı - HastaneKlinik
        public List<HastaneKlinik> HastaneKlinikler { get; } = new();
        public List<Hastane> Hastaneler { get; } = new();


    }
}
