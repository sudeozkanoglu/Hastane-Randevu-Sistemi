namespace webProjeOdev8.Models
{
    public class HastanePoliklinik
    {

        public int hastaneId { get; set; }
        public int poliklinikId { get; set; }
        public Hastane Hastane { get; set; } = null!;
        public Poliklinik Poliklinik { get; set; } = null!;

    }
}
