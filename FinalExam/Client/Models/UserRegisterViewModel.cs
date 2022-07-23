﻿using System.ComponentModel.DataAnnotations;

namespace FinalExam.Client.Models
{
	public class UserRegisterViewModel
	{
		[Required, EmailAddress]
		public string Email { get; set; } = String.Empty;
		[Required, StringLength(100, MinimumLength = 6)]
		public string Password { get; set; } = String.Empty;
		[Compare("Password", ErrorMessage = "The passwords do not match")]
		public string ConfirmPassword { get; set; } = String.Empty;
	}
}
