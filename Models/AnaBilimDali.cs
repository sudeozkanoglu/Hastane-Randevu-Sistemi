using System.ComponentModel.DataAnnotations;

namespace webProjeOdev8.Models
{
    public class AnaBilimDali
    {
        [Key]
        public int anaBilimDaliId { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Ana Bilim Dalı Adı")]
        public string anaBilimDaliAdi { get; set; }

        //*******************************************************

        public ICollection<Doktor> Doktorlar { get; set; }
        public ICollection<Klinik> Klinikler { get; set; }
        public ICollection<Randevu> Randevular { get; set; }

        //********************************************************
        //Çok a çok ilişki kısmı - HastaneAnaBilimDali
        public List<HastaneAnaBilim> HastaneAnaBilimler { get; } = new();
        public List<Hastane> Hastaneler { get; } = new();

    }
}
