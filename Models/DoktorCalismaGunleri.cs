using webProjeOdev8.Models;

namespace webProjeOdev8.Models
{
    public class DoktorCalismaGunleri
    {
        public int doktorId { get; set; }
        public int calismaGunleriId { get; set; }
        public Doktor Doktor { get; set; } = null!;
        public CalismaGunleri CalismaGunleri { get; set; } = null!;
    }
}
