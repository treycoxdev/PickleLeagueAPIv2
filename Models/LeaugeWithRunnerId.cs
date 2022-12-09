namespace PickleLeaugev4.Models
{
    public class LeaugeWithRunnerId
    {
        public int LeaugeId { get; set; }
        public string LeaugeName { get; set; }
        public DateTime? LeaugeStartDate { get; set; }
        public int LeagueType { get; set; }
        public int LeaugeRunnerId { get; set; }
    }
}
