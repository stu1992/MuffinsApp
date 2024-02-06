namespace ProfileServer.Models
{
    public class User
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
    }

    public class CreateNewUserRequest : User
    {
        public int[] profiles { get; set; }
    }

    public class UpdateUserProfileRequest
    {
        public string email { get; set; }
        public int[] profiles { get; set; }
    }
}