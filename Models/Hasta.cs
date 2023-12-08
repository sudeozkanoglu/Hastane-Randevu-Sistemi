using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webProjeOdev.Models
{
    public class Hasta
    {
        [Key]
        public int hastaId { get; set; }

        [Required]
        [MaxLength(11)]
        [Display(Name ="Kimlik Numarası")]
        public string hastaTC { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="Hasta Adı")]
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
        [Display(Name="Şifre")]
        public string hastaSifre { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "user"; //migration yapip orayi da user olarak ayarladik

        [ForeignKey("IletisimBilgileri")]
        public int iletisimId { get; set; }
        public IletisimBilgileri IletisimBilgileri { get; set; } = null!;

        //*******************************************************
        public ICollection<Randevu> Randevular { get; set; }


        //********************************************************
        //Çok a çok ilişki kısmı 
        public List<HastaneHasta> HastaneHastalar { get; } = new();
        public List<Hastane> Hastaneler { get; } = new();
    }
}
