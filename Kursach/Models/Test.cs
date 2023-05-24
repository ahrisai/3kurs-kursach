namespace Kursach.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string TestTitle{ get; set; }
        public bool EditMode { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime DurationTime { get; set; }
        public int UserId { get; set; }
        public ICollection <Question> Questions{ get; set; }
    }
}
