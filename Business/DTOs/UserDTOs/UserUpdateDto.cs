namespace Business.DTOs.UserDTOs
{
    public class UserUpdateDto
    {
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }

        public bool? IsBanned { get; set; }
    }
}
