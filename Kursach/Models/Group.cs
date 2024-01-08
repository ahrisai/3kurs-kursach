namespace Kursach.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string GroupName { get; set; }

        public string GroupImg { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

       

        
    }
}
