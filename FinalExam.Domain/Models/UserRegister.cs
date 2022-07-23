namespace FinalExam.Domain.Models
{
    public class UserRegister
    {
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string ConfirmPassword { get; set; } = String.Empty;
    }
}
