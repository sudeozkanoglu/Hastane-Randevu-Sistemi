using System.ComponentModel.DataAnnotations;

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

        //*******************************************************
        public ICollection<IletisimBilgileri> IletisimBilgileri { get; set; }
    }
}
