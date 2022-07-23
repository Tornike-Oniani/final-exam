using System.ComponentModel.DataAnnotations;

namespace FinalExam.Client.Models
{
	public class UserLoginViewModel
	{
		[Required]
		public string Email { get; set; } = String.Empty;
		[Required]
		public string Password { get; set; } = String.Empty;
	}
}
