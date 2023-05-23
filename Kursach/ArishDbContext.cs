using Kursach.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Kursach
{
    public class ArishDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }

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
