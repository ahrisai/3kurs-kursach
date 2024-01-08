using System.Numerics;

namespace Kursach.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string TestTitle{ get; set; }
        public byte EditMode { get; set; }
        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string DurationTime { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }

        
        public ICollection <Question> Questions{ get; set; }
    }
}
