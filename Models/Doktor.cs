using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webProjeOdev.Models
{
    public class Doktor
    {
        [Key]
        public int doktorId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="Doktor Adı")]
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


        public Poliklinik Poliklinik { get; set; }


        //****************************************************************
        
        public ICollection<Randevu> Randevular { get; set; }
        public List<DoktorCalismaGunleri> DoktorCalismaGunleri { get; } = new();
    }
}
