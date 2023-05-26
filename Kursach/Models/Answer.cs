namespace Kursach.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }

        public string AnswerValue { get; set; }

        public string RightValue{ get; set; }


    }
}
