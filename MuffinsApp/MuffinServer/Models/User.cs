namespace MuffinServer.Models
{
    public class User
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
    }

    public class NewUser : User
    {
        public int[] profiles { get; set; }
    }
}