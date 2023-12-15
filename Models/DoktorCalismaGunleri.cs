using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webProjeOdev2.Data.Enum;

namespace webProjeOdev2.Models
{
    public class DoktorCalismaGunleri
    {
        [Key]
        public int doktorCalismaGunleriId { get; set; }

        [Required]
        [Display(Name = "Çalışma Günleri")]
        public CalismaGunleri calismaGunleri { get; set; }

        [Required]
        [Column(TypeName = "time")]
        [Display(Name = "Çalışma Saatleri")]
        public TimeSpan calismaSaat { get; set; }



//**************************************************************************
        [ForeignKey("Doktor")]
        public int doktorId { get; set; }
        public Doktor Doktor { get; set; } = null!;
    }
}
