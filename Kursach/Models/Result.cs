namespace Kursach.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }

        public int GroupId { get; set; }
        public Group Group{ get; set; }
        public int Mark { get; set; }

        public ICollection<UserAnswer> UserAnswers { get; set; }

    }
}
