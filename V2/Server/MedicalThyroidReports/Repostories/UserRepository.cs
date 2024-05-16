namespace MedicalThyroidReports.Repostories
{
    using MedicalThyroidReports.Modals;
    using MySql.Data.MySqlClient;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }
        public async Task<bool> IsUsernameTaken(string username)
        {
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("SELECT COUNT(*) FROM Users WHERE UserName = @UserName", connection);
                command.Parameters.AddWithValue("@UserName", username);

                var result = (long)await command.ExecuteScalarAsync();

                return result > 0;
            }
        }

        public async Task<bool> IsEmailRegistered(string email)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("SELECT COUNT(*) FROM Users WHERE Email = @Email", connection);
                command.Parameters.AddWithValue("@Email", email);

                var result = (long) await command.ExecuteScalarAsync();

                return result > 0;
            }
        }

        public async Task AddUserAsync(User user)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("INSERT INTO Users (UserName, Email, PasswordHash) VALUES (@UserName, @Email, @PasswordHash)", connection);
                command.Parameters.AddWithValue("@Username", user.UserName);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);

                await command.ExecuteNonQueryAsync();
            }
        }
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT Id, Username, Email, PasswordHash FROM Users WHERE UserName = @UserName";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new User
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash"))
                            };
                        }
                        else
                        {
                            return null; // User not found
                        }
                    }
                }
            }
        }
        
    public async Task<User> AuthenticateAsync(string email, string password)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            // Query user by username
            var query = "SELECT Id, Email, PasswordHash FROM Users WHERE Email = @Email";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (!reader.HasRows)
                        return null; // User not found

                    await reader.ReadAsync();
                    var userId = reader.GetInt32(0);
                    var storedEmail = reader.GetString(1);
                    var storedPasswordHash = reader.GetString(2);

                    // Validate password using bcrypt
                    if (!BCrypt.Net.BCrypt.Verify(password, storedPasswordHash))
                        return null; // Invalid password

                    return new User { Id = userId, Email = storedEmail };
                }
            }
        }
    }

    }

}
