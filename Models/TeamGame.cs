namespace PickleLeaugev4.Models
{
    public class TeamGame
    {
        public int TeamGameId { get; set; }
        public int? TeamOneId { get; set; }
        public int? TeamTwoId { get; set; }
        public int? TeamOneScore { get; set; }
        public int? TeamTwoScore { get; set; }
        public DateTime? GameTime { get; set; }
        public string? CourtName { get; set; }
        public int? SessionId { get; set; }
        public int? WinnerId { get; set; }
    }
}
