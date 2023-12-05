using System.ComponentModel.DataAnnotations;

namespace webProjeOdev.Models
{
    public class Hastane
    {
        [Key]
        public int hastaneId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="Hastane Adı")]
        public string hastaneAdi { get; set; }

        //**************************************************************************

        public ICollection<Doktor> Doktorlar { get; set; }
        public ICollection<IletisimBilgileri> IletisimBilgileri { get; set; }
        public ICollection<Randevu> Randevular { get; set; }

        //********************************************************
        //Çok a çok ilişki kısmı - HastaneHasta
        public List<HastaneHasta> HastaneHastalar { get; } = new();
        public List<HastaIletisim> Hastalar { get; } = new();

        //********************************************************
        //Çok a çok ilişki kısmı - HastaneAnaBilimDali
        public List<HastaneAnaBilim> HastaneAnaBilimler { get; } = new();
        public List<AnaBilimDali> AnaBilimDallari { get; } = new();

        //********************************************************
        //Çok a çok ilişki kısmı - HastaneKlinik
        public List<HastaneKlinik> HastaneKlinikler { get; } = new();
        public List<Klinik> Klinikler { get; } = new();

        //********************************************************
        //Çok a çok ilişki kısmı - HastanePoliklinik
        public List<HastanePoliklinik> HastanePoliklinikler { get; } = new();
        public List<Poliklinik> Poliklinikler { get; } = new();

    }
}
