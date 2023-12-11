using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webProjeOdev.Models
{
    public class Hastane
    {
        [Key]
        public int hastaneId { get; set; }

        [Required(ErrorMessage ="Hastane Adı Uygun Değil")]
        [MaxLength(100)]
        [Display(Name ="Hastane Adı")]
        public string hastaneAdi { get; set; }

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

        //**************************************************************************

        public ICollection<Doktor> Doktorlar { get; set; }
        public ICollection<Randevu> Randevular { get; set; }

        //********************************************************
        //Çok a çok ilişki kısmı - HastaneHasta
        public List<HastaneHasta> HastaneHastalar { get; } = new();
        public List<Hasta> Hastalar { get; } = new();

        //********************************************************
        //Çok a çok ilişki kısmı - HastaneAnaBilimDali
        public List<HastaneAnaBilim> HastaneAnaBilimler { get; } = new();
        public List<AnaBilimDali> AnaBilimDallari { get; } = new();

        //********************************************************
        //Çok a çok ilişki kısmı - HastaneKlinik
        public List<HastaneKlinik> HastaneKlinikler { get; } = new();
        public List<Klinik> Klinikler { get; } = new();

        //********************************************************
        //Çok a çok ilişki kısmı - HastanePoliklinik
        public List<HastanePoliklinik> HastanePoliklinikler { get; } = new();
        public List<Poliklinik> Poliklinikler { get; } = new();
    }
}
