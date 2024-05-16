using MedicalThyroidReports.Modals;

namespace MedicalThyroidReports.Services
{
    public interface IUserService
    {
        Task<RegistrationResult> RegisterAsync(RegisterRequest modal);
        Task<User> AuthenticateAsync(string username, string password);
        Task<string> AuthenticateAsync(Login model);

    }
}
