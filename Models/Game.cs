namespace PickleLeaugev4.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public int? IdOne{ get; set; }
        public int? IdTwo { get; set; }
        public int? ScoreOne { get; set; }
        public int? ScoreTwo { get; set; }
        public DateTime GameTime { get; set; }
        public string CourtName { get; set; }
        public int? SessionId { get; set; }
        public int? WinnerId { get; set; }
        public string GameType { get; set; }
    }
}
