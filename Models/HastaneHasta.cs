namespace webProjeOdev.Models
{
    public class HastaneHasta
    {
        public int hastaneId { get; set; }
        public int hastaId { get; set; }
        public Hastane Hastane { get; set; } = null!;
        public HastaIletisim Hasta { get; set; } = null!;
    }
}
