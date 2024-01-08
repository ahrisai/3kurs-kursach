using Kursach.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Kursach
{
    public class ArishDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }

        public DbSet<GroupTest> GroupTests { get; set; }

        public ArishDbContext()
            
        {
          
        }
        public bool IsDatabaseConnected()
        {
            try
            {
                return Database.CanConnect();
            }
            catch
            {
                return false;
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-S92B9CN;Database=ArishTestDB;User Id=pups;Password=1234;TrustServerCertificate=True;");
        }
    }
}
