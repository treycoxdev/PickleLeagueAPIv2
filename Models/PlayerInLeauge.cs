using Microsoft.EntityFrameworkCore;

namespace PickleLeaugev4.Models
{
    
    public class PlayerInLeauge
    {
        public int ID {get; set;}
        public int PlayerId { get; set; }
        public int LeaugeId { get; set; }
    }
}
