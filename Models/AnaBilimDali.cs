using System.ComponentModel.DataAnnotations;

namespace webProjeOdev.Models
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


    }
}
