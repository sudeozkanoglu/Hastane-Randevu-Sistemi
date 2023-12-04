using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webProjeOdev.Models
{
    public class Klinik
    {
        [Key]
        public int klinikId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="Klinik Adı")]
        public string klinikAdi { get; set; }

        //*******************************************************

        [ForeignKey("AnaBilimDali")]
        public int anaBilimDaliId { get; set; }
        public AnaBilimDali AnaBilimDali { get; set; } = null!;

        //**********************************************************

        public ICollection<Doktor> Doktorlar { get; set; }
        public ICollection<Poliklinik> Poliklinikler { get; set; }

    }
}
