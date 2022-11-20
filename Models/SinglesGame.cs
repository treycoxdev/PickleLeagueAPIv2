namespace PickleLeaugev4.Models
{
    public class SinglesGame
    {
        public int SinglesGameId { get; set; }
        public int? PlayerOneId { get; set; }
        public int? PlayerTwoId { get; set; }
        public int? PlayerOneScore { get; set; }
        public int? PlayerTwoScore { get; set; }
        public DateTime GameTime { get; set; }
        public string CourtName { get; set; }
        public int? SessionId { get; set; }
        public int? WinnerId { get; set; }
    }
}
