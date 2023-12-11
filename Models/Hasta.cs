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

        [Required(ErrorMessage = "Telefon Numarası Gerekli")]
        [Phone(ErrorMessage = "Telefon Numarası Uygun Değil")]
        [Display(Name = "Telefon Numarası")]
        public string telefonNumarasi { get; set; }

        [Required(ErrorMessage = "EmaiL gEREKLİ")]
        [EmailAddress(ErrorMessage = "Email biçimi düzgün değil")]
        [Display(Name = "E-mail Adresi")]
        public string email { get; set; }

        [Required(ErrorMessage = "İl seçimi zorunlu")]
        [Display(Name = "İl")]
        public Il Iller { get; set; }

        public enum Il
        {
            Adana,
            Adıyaman,
            Afyonkarahisar,
            Ağrı,
            Aksaray,
            Amasya,
            Ankara,
            Antalya,
            Ardahan,
            Artvin,
            Aydın,
            Balıkesir,
            Bartın,
            Batman,
            Bayburt,
            Bilecik,
            Bingöl,
            Bitlis,
            Bolu,
            Burdur,
            Bursa,
            Çanakkale,
            Çankırı,
            Çorum,
            Denizli,
            Diyarbakır,
            Düzce,
            Edirne,
            Elazığ,
            Erzincan,
            Erzurum,
            Eskişehir,
            Gaziantep,
            Giresun,
            Gümüşhane,
            Hakkari,
            Hatay,
            Iğdır,
            Isparta,
            İstanbul,
            İzmir,
            Kahramanmaraş,
            Karabük,
            Karaman,
            Kars,
            Kastamonu,
            Kayseri,
            Kırıkkale,
            Kırklareli,
            Kırşehir,
            Kilis,
            Kocaeli,
            Konya,
            Kütahya,
            Malatya,
            Manisa,
            Mardin,
            Mersin,
            Muğla,
            Muş,
            Nevşehir,
            Ordu,
            Osmaniye,
            Rize,
            Sakarya,
            Samsun,
            Siirt,
            Sinop,
            Sivas,
            Şanlıurfa,
            Şırnak,
            Tekirdağ,
            Tokat,
            Trabzon,
            Tunceli,
            Uşak,
            Van,
            Yalova,
            Yozgat,
            Zonguldak
        }

        //*******************************************************
        public ICollection<Randevu> Randevular { get; set; }


        //********************************************************
        //Çok a çok ilişki kısmı 
        public List<HastaneHasta> HastaneHastalar { get; } = new();
        public List<Hastane> Hastaneler { get; } = new();
    }
}
