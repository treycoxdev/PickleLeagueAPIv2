using Microsoft.EntityFrameworkCore;

namespace PickleLeaugev4.Models
{
    
    public class LeaugeUnderLeaugeRunner
    {
        public int Id { get; set; }
        public int LeaugeId { get; set; }
        public int LeagueRunnerId { get; set; }
    }
}
