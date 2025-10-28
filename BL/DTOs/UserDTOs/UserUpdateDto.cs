namespace BL.DTOs.UserDTOs
{
    public class UserUpdateDto
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public bool IsBanned { get; set; }
    }
}
