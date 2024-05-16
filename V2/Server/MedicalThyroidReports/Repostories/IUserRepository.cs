using MedicalThyroidReports.Modals;

namespace MedicalThyroidReports.Repostories
{
    public interface IUserRepository
    {
        Task<bool> IsUsernameTaken(string username);
        Task <bool> IsEmailRegistered(string email);
        Task AddUserAsync(User user);
        Task <User>AuthenticateAsync(string email,string password); 
        Task<User> GetUserByUsernameAsync(string username);
    }
}
