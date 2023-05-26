﻿namespace Kursach.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionType { get; set; }
        public string QuestionText { get; set; }

        public int TestId { get; set; }
        public ICollection<Answer> Answers{ get; set; }

    }
}
