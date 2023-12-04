using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webProjeOdev.Data.Enum;

namespace webProjeOdev.Models
{
    public class IletisimBilgileri
    {
        [Key]
        public int iletisimId { get; set; }

        [Required]
        [Phone]
        [Display(Name ="Telefon Numarası")]
        public string telefonNumarasi { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name ="E-mail Adresi")]
        public string email { get; set; }

        [Required]
        [Display(Name ="İl")]
        public Il Iller { get; set; }
        
        //******************************************************

        [ForeignKey("Hasta")]
        public int hastaId { get; set; }
        public Hasta Hasta { get; set; } = null!;

        [ForeignKey("Doktor")]
        public int doktorId { get; set; }
        public Doktor Doktor { get; set; } = null!;

        [ForeignKey("Hastane")]
        public int hastaneId { get; set; }
        public Hastane Hastane { get; set; } = null!;

        //***************************************************
    }
}
