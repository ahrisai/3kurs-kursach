namespace Kursach.Models
{
    public class Group
    {
        public int Id { get; set; }

        public int AdminId{ get; set; }

        public string GroupName { get; set; }

        public ICollection<User>Members { get; set; }

        public ICollection<Test>GroupTests { get; set; }
    }
}
