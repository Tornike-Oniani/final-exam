namespace FinalExam.Client.Services.AuthService
{
	public class AuthService : IAuthService
	{
		private readonly HttpClient _http;

		public AuthService(HttpClient http)
		{
			this._http = http;
		}

		public async Task<ServiceResponseViewModel<string>> Login(UserLoginViewModel request)
		{
			var result = await _http.PostAsJsonAsync("api/auth/login", request);
			return await result.Content.ReadFromJsonAsync<ServiceResponseViewModel<string>>();
		}

		public async Task<ServiceResponseViewModel<int>> Register(UserRegisterViewModel request)
		{
			var result = await _http.PostAsJsonAsync("api/auth/register", request);
			return await result.Content.ReadFromJsonAsync<ServiceResponseViewModel<int>>();
		}

		public async Task<ServiceResponseViewModel<bool>> ChangePassword(UserChangePasswordViewModel request)
		{
			var result = await _http.PostAsJsonAsync("api/auth/change-password", request.Password);
			return await result.Content.ReadFromJsonAsync<ServiceResponseViewModel<bool>>();
		}
	}
}
