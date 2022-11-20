using Microsoft.EntityFrameworkCore;

namespace PickleLeaugev4.Models
{
    [Keyless]
    public class SessionInLeauge
    {
        public int SessionId { get; set; }
        public int LeaugeId { get; set; }
    }
}
