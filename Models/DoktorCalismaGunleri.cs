namespace webProjeOdev.Models
{
    public class DoktorCalismaGunleri
    {
        public int doktorId { get; set; }
        public int calismaGunleriId { get; set; }
        public Doktor Doktor { get; set; } = null!;
        public CalismaGunleri CalismaGunleri { get; set; } = null!;
    }
}
