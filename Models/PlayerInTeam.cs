using Microsoft.EntityFrameworkCore;

namespace PickleLeaugev4.Models
{
    public class PlayerInTeam
    {
        public int ID { get; set; }
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
    }
}
