namespace api.Models
{
    public class RegisterUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nationality { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int RoleId { get; set; } = 1;
    }
}