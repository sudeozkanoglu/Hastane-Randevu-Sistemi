﻿using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace webProjeOdev.Models
{
    public class Poliklinik
    {
        [Key]
        public int poliklinikId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Poliklinik Adı")]
        public string poliklinikAdi { get; set; }

        //*******************************************************

        [ForeignKey("Klinik")]
        public int klinikId { get; set; }
        public Klinik Klinik { get; set; } = null!;

        public int doktorId { get; set; }
        public Doktor Doktor { get; set; }

        //*********************************************************
        public ICollection<Randevu> Randevular { get; set; }

        //********************************************************
        //Çok a çok ilişki kısmı - HastanePoliklinik

        public List<HastanePoliklinik> HastanePoliklinikler { get; } = new();
        public List<Hastane> Hastaneler { get; } = new();


    }
}
