using Microsoft.EntityFrameworkCore;

namespace PickleLeaugev4.Models
{
    [Keyless]
    public class LeaugeUnderLeaugeRunner
    {
        public int LeaugeId { get; set; }
        public int LeagueRunnerId { get; set; }
    }
}
