using Microsoft.EntityFrameworkCore;

namespace PickleLeaugev4.Models
{
    [Keyless]
    public class LeaugeInClub
    {
        public int LeaugeId { get; set; }
        public int ClubId { get; set; }
    }
}
