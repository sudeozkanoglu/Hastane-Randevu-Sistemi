using System.ComponentModel.DataAnnotations;
using webProjeOdev2.Data.Enum;

namespace webProjeOdev2.Models
{
    public class Hasta
    {
        [Key]
        public int hastaId { get; set; }

        [Required]
        [MaxLength(11)]
        [Display(Name = "Kimlik Numarası")]
        public string hastaTC { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Hasta Adı")]
        public string hastaAdi { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Hasta Soyadı")]
        public string hastaSoyadi { get; set; }

        [Required]
        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dogumTarihi { get; set; }

        [Required]
        [Display(Name = "Cinsiyet\n")]
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
        [Display(Name = "Şifre")]
        public string hastaSifre { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "user";//migration yapip orayi da user olarak ayarladik

        //*******************************************************

        public ICollection<Randevu> Randevular { get; set; }


        //********************************************************
        //Çok a çok ilişki kısmı 
        public List<HastaneHasta> HastaneHastalar { get; } = new();
        public List<Hastane> Hastaneler { get; } = new();

    }
}
