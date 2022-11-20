using Microsoft.EntityFrameworkCore;
using PickleLeaugev4.Models;

namespace PickleLeaugev4.Data { 
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<Leauge> Leauges { get; set; }
        public DbSet<LeaugeInClub> LeaugeInClubs { get; set; }
        public DbSet<LeaugeRunner> LeaugeRunners { get; set; }
        public DbSet<LeaugeRunnerInClub> LeaugeRunnerInClubs { get; set; }
        public DbSet<LeaugeUnderLeaugeRunner> LeaugeUnderLeaugeRunner { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerInLeauge> PlayersInLeauges { get; set; }
        public DbSet<PlayerInTeam> PlayersInTeams { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionInLeauge> SessionsInLeauges { get; set; }
        public DbSet<SinglesGame> SinglesGames { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamGame> TeamGames { get; set; }
        public DbSet<TeamInLeauge> TeamInLeauges { get; set; }
    }
}
