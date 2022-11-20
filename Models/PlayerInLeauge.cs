using Microsoft.EntityFrameworkCore;

namespace PickleLeaugev4.Models
{
    [Keyless]
    public class PlayerInLeauge
    {
        public int PlayerId { get; set; }
        public int LeaugeId { get; set; }
    }
}
