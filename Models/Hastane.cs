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

        [Required]
        [MaxLength(255)]
        [Display(Name = "Ana Bilim Dalı/Dalları Adı/Adları")]
        public string anaBilimDaliAdi { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Klinik Adı/Adları")]
        public string klinikAdi { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Poliklinik Adı/Adları")]
        public string poliklinikAdi { get; set; }

        //**************************************************************************

        public ICollection<Doktor> Doktorlar { get; set; }
        public ICollection<IletisimBilgileri> IletisimBilgileri { get; set; }

    }
}
