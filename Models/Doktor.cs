using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using webProjeOdev2.Data.Enum;

namespace webProjeOdev2.Models
{
    public class Doktor
    {

        [Key]
        public int doktorId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Doktor Adı")]
        public string doktorAdi { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Doktor Soyadı")]
        public string doktorSoyadi { get; set; }

        [Required]
        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dogumTarihi { get; set; }

        [Required]
        [Display(Name = "Cinsiyet")]
        public Cinsiyet cinsiyet { get; set; }

        public enum Cinsiyet
        {
            Kadın,
            Erkek
        }

        [Required]
        [Display(Name = "Medeni Hal")]
        public MedeniHal medeniHal { get; set; }

        public enum MedeniHal
        {
            Evli,
            Bekar
        }
        [Required]
        [Phone]
        [Display(Name = "Telefon Numarası")]
        public string telefonNumarasi { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail Adresi")]
        public string email { get; set; }

        [Required]
        [Display(Name = "İl")]
        public Il Iller { get; set; }

        [Required]
        [Display(Name = "Çalışma Günleri")]
        public CalismaGunleri calismaGunleri { get; set; }

        [Required]
        [Column(TypeName = "time")]
        [Display(Name = "Çalışma Saatleri")]
        public TimeSpan calismaSaat { get; set; }

        //***************************************************************

        [ForeignKey("AnaBilimDali")]
        public int anaBilimDaliId { get; set; }
        public AnaBilimDali AnaBilimDali { get; set; } = null!;

        [ForeignKey("Klinik")]
        public int klinikId { get; set; }
        public Klinik Klinik { get; set; } = null!;

        [ForeignKey("Hastane")]
        public int hastaneId { get; set; }
        public Hastane Hastane { get; set; } = null!;

        [ForeignKey("Poliklinik")]
        public int poliklinikId { get; set; }
        public Poliklinik Poliklinik { get; set; } = null!;

        //****************************************************************

        public ICollection<Randevu> Randevular { get; set; }

    }
}
