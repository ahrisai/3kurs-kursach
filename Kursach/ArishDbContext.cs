using Kursach.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Kursach
{
    public class ArishDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public ArishDbContext(DbContextOptions<ArishDbContext> options)
            : base(options)
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
            optionsBuilder.UseSqlServer("DefaultConnection");
        }
    }
}
