namespace webProjeOdev.Models
{
    public class HastaneAnaBilim
    {
        public int hastaneId { get; set; }
        public int anaBilimDaliId { get; set; }
        public Hastane Hastane { get; set; } = null!;
        public AnaBilimDali AnaBilimDali { get; set; } = null!;
    }
}
