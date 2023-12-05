using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webProjeOdev.Models
{
    public class Randevu
    {
        [Key]
        public int randevuId { get; set; }

        [Required]
        [Display(Name = "Randevu Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime randevuTarihi { get; set; }

        [Required]
        [Column(TypeName = "time")]
        [Display(Name = "Randevu Saati")]
        public TimeSpan randevuSaat { get; set; }

        //************************************************
        //foreign key kısımları 
        [ForeignKey("Hastane")]
        public int hastaneId { get; set; }
        public Hastane Hastane { get; set; } = null!;

        [ForeignKey("AnaBilimDali")]
        public int anaBilimDaliId { get; set; }
        public AnaBilimDali AnaBilimDali { get; set; } = null!;

        [ForeignKey("Klinik")]
        public int klinikId { get; set; }
        public Klinik Klinik { get; set; } = null!;

        [ForeignKey("Poliklinik")]
        public int poliklinikId { get; set; }
        public Poliklinik Poliklinik { get; set; } = null!;

        [ForeignKey("Doktor")]
        public int doktorId { get; set; }
        public Doktor Doktor { get; set; } = null!;

        [ForeignKey("Hasta")]
        public int hastaId { get; set; }
        public HastaIletisim Hasta { get; set; } = null!;
    }
}
