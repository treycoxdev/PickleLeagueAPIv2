using Microsoft.EntityFrameworkCore;

namespace PickleLeaugev4.Models
{
    [Keyless]
    public class LeaugeRunnerInClub
    {
        public int LeaugeRunnerId{ get; set;} 
        public int ClubId{ get; set;}
    }
}
