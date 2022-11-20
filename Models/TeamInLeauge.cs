using Microsoft.EntityFrameworkCore;

namespace PickleLeaugev4.Models
{
    [Keyless]
    public class TeamInLeauge
    {
        public int TeamId { get; set; }
        public int LeaugeId { get; set; }
    }
}
