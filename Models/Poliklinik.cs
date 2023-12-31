using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webProjeOdev8.Models
{
    public class Poliklinik
    {
        [Key]
        public int poliklinikId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Poliklinik Adı")]
        public string poliklinikAdi { get; set; }



        public int doktorId { get; set; }
        public Doktor Doktor { get; set; } = null!;
        //*******************************************************

        [ForeignKey("Klinik")]
        public int klinikId { get; set; }
        public Klinik Klinik { get; set; } = null!;

        //*********************************************************
        public ICollection<Randevu> Randevular { get; set; }

        //********************************************************
        //Çok a çok ilişki kısmı - HastanePoliklinik
        public List<Hastane> Hastaneler { get; } = new();
        public List<HastanePoliklinik> HastanePoliklinikler { get; } = new();

    }
}
