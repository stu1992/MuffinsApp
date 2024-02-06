namespace ProfileServer.Models
{
    public class Profile
    {
        public string profileName { get; set; }
        public string profileDescription { get; set; }
    }

    public class UpdateProfileRequest : Profile
    {
        public int profileId { get; set; }
    }
}