using Microsoft.EntityFrameworkCore;
using Task_1.HW;
namespace Task_2.HW
{
    public class MyDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-2;Initial Catalog=FootballTeamsDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasKey(t => t.TeamId);
        }
    }
    public class Match
    {
        public int MatchId { get; set; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
        public int? GoalsTeam1 { get; set; }
        public int? GoalsTeam2 { get; set; }
        public int? ScorerId { get; set; }
        public DateTime MatchDate { get; set; }
    }
    public class Player
    {
        public int PlayerId { get; set; }
        public string FullName { get; set; }
        public string Country { get; set; }
        public int JerseyNumber { get; set; }
        public string Position { get; set; }
        public Match MatchId { get; set; }
        public int? ScorerId { get; set; }
        public DateTime MatchDate { get; set; }
        public Match Match { get; set; }
        public decimal Goals { get; set; }
    }
}