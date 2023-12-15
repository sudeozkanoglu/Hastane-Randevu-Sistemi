namespace webProjeOdev2.Models
{
    public class HastaneHasta
    {
        public int hastaneId { get; set; }
        public int hastaId { get; set; }
        public Hastane Hastane { get; set; } = null!;
        public Hasta Hasta { get; set; } = null!;

    }
}
