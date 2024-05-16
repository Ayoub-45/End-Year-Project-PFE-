using MedicalThyroidReports.Modals;
using MedicalThyroidReports.Repostories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedicalThyroidReports.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    public async Task<RegistrationResult> RegisterAsync(RegisterRequest modal)
    {
        if(string.IsNullOrWhiteSpace(modal.UserName) || string.IsNullOrWhiteSpace(modal.Email) || string.IsNullOrWhiteSpace(modal.Password))
        {
            return new RegistrationResult { Success = false, ErrorMessage = "UserName , email or password are required." };
        }
        if(await _userRepository.IsUsernameTaken(modal.UserName) )
        {
                return new RegistrationResult { Success = false, ErrorMessage = "UserName is already taken" };
        }
        if (await _userRepository.IsEmailRegistered(modal.Email))
            {
                return new RegistrationResult { Success = false, ErrorMessage="Email is already registered." };
            }
        string hashedPassword=HashPassword(modal.Password);
            var user = new User
            {
                UserName = modal.UserName,
                Email = modal.Email,
                PasswordHash = hashedPassword
            };
            await _userRepository.AddUserAsync(user);
            return new RegistrationResult { Success = true};
    }
        public async Task<User> AuthenticateAsync(string username, string password)
        {
            try
            {
                // Retrieve user from database based on username
                var user = await _userRepository.GetUserByUsernameAsync(username);

                // Check if user exists and verify password
                if (user != null && VerifyPassword(password, user.PasswordHash))
                {
                    return user; // Authentication successful
                }

                return null; // Authentication failed
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred during user authentication: {ex.Message}");
                return null;
            }
        }
        private string HashPassword(string password) {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        private bool VerifyPassword(string password, string hashedPassword)
        {
            // Verify the password against the hashed password
            // Using the same hashing algorithm used during registration
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        public async Task<string> Authenticate(Login model)
        {
            // Authenticate user (validate credentials)
            var user = await _userRepository.AuthenticateAsync(model.Email, model.Password);
            if (user == null)
                return null; // Authentication failed

            // Create JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("your-secret-key"); // Replace with your secret key
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(1), // Token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
