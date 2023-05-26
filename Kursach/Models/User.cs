namespace Kursach.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public string UserPassword { get; set; }

        public string UserAvatar { get; set; }

        public ICollection<Test>Tests { get; set; }
    }
}
