namespace Kursach.Models
{
    public class GroupTest
    {
        public int Id { get; set; }
        public int TestId { get; set; }

        public Test Test { get; set; } 
        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}
