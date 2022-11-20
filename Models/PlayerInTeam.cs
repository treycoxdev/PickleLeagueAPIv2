using Microsoft.EntityFrameworkCore;

namespace PickleLeaugev4.Models
{
    [Keyless]
    public class PlayerInTeam
    {
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
    }
}
