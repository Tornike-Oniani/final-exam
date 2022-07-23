namespace FinalExam.Client.Services.AuthService
{
	public interface IAuthService
	{
		Task<ServiceResponseViewModel<string>> Login(UserLoginViewModel request);
		Task<ServiceResponseViewModel<int>> Register(UserRegisterViewModel request);
		Task<ServiceResponseViewModel<bool>> ChangePassword(UserChangePasswordViewModel request);
	}
}
