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

        //******************************************************

        public ICollection<Doktor> Doktorlar { get; set; }
        public ICollection<Hastane> Hastaneler { get; set; }
        public ICollection<Hasta> Hastalar { get; set; }


        //***************************************************
    }
}
