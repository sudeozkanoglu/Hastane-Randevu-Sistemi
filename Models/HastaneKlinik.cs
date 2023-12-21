namespace webProjeOdev8.Models
{
    public class HastaneKlinik
    {
        public int hastaneId { get; set; }
        public int klinikId { get; set; }
        public Hastane Hastane { get; set; } = null!;
        public Klinik Klinik { get; set; } = null!;

    }
}
