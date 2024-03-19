
using MySql.Data.MySqlClient;
using MedicalThyroidReportsAPI.Modals;
using MedicalThyroidReportsAPI.Repositories;
using System.Configuration;

namespace MedicalThyroidReportsAPI.Repositories
{
    public class StudyThyroidRepository
    {

        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        public StudyThyroidRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
            _configuration = configuration;

        }

        public async Task<IEnumerable<StudyThyroid>> GetAllStudyThyroidsAsync()
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = "SELECT * FROM StudyThyroid";
            using var command = new MySqlCommand(query, connection);
            using var reader = await command.ExecuteReaderAsync();

            var studyThyroids = new List<StudyThyroid>();
            while (await reader.ReadAsync())
            {
                studyThyroids.Add(await MapToStudyThyroid((MySqlDataReader)reader));
            }

            return studyThyroids;
        }

        public async Task<StudyThyroid> GetStudyThyroidByIdAsync(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = "SELECT * FROM StudyThyroid WHERE Id = @Id";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return await MapToStudyThyroid((MySqlDataReader)reader);
            }

            return null;
        }

        public async Task AddStudyThyroidAsync(StudyThyroid studyThyroid)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = "INSERT INTO StudyThyroid (IdRadiologist, TypeOfStudy, DateStudy, Volume, Vascularization, Echogenicity, LymphNodeUltra, ThyroglossalTracStudy, Recommendation) " +
                        "VALUES (@IdRadiologist, @TypeOfStudy, @DateStudy, @Volume, @Vascularization, @Echogenicity, @LymphNodeUltra, @ThyroglossalTracStudy, @Recommendation)";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdRadiologist", studyThyroid.IdRadiologist);
            command.Parameters.AddWithValue("@TypeOfStudy", studyThyroid.TypeOfStudy);
            command.Parameters.AddWithValue("@DateStudy", studyThyroid.DateStudy);
            command.Parameters.AddWithValue("@Volume", studyThyroid.Volume);
            command.Parameters.AddWithValue("@Vascularization", studyThyroid.Vascularization);
            command.Parameters.AddWithValue("@Echogenicity", studyThyroid.Echogenicity);
            command.Parameters.AddWithValue("@LymphNodeUltra", studyThyroid.LymphNodeUltra);
            command.Parameters.AddWithValue("@ThyroglossalTracStudy", studyThyroid.ThyroglossalTracStudy);
            command.Parameters.AddWithValue("@Recommendation", studyThyroid.Recommendation);

            await command.ExecuteNonQueryAsync();
        }

        public async Task UpdateStudyThyroidAsync(StudyThyroid studyThyroid)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = "UPDATE StudyThyroid SET IdRadiologist = @IdRadiologist, TypeOfStudy = @TypeOfStudy, DateStudy = @DateStudy, " +
                        "Volume = @Volume, Vascularization = @Vascularization, Echogenicity = @Echogenicity, " +
                        "LymphNodeUltra = @LymphNodeUltra, ThyroglossalTracStudy = @ThyroglossalTractStudy, " +
                        "Recommendation = @Recommendation WHERE Id = @Id";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", studyThyroid.Id);
            command.Parameters.AddWithValue("@IdRadiologist", studyThyroid.IdRadiologist);
            command.Parameters.AddWithValue("@TypeOfStudy", studyThyroid.TypeOfStudy);
            command.Parameters.AddWithValue("@DateStudy", studyThyroid.DateStudy);
            command.Parameters.AddWithValue("@Volume", studyThyroid.Volume);
            command.Parameters.AddWithValue("@Vascularization", studyThyroid.Vascularization);
            command.Parameters.AddWithValue("@Echogenicity", studyThyroid.Echogenicity);
            command.Parameters.AddWithValue("@LymphNodeUltra", studyThyroid.LymphNodeUltra);
            command.Parameters.AddWithValue("@ThyroglossalTractStudy", studyThyroid.ThyroglossalTractStudy);
            command.Parameters.AddWithValue("@Recommendation", studyThyroid.Recommendation);

            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteStudyThyroidAsync(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = "DELETE FROM StudyThyroid WHERE Id = @Id";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            await command.ExecuteNonQueryAsync();
        }

        private async Task<StudyThyroid> MapToStudyThyroid(MySqlDataReader reader)
        {
            var studyThyroid = new StudyThyroid
            {
                Id = Convert.ToInt32(reader["Id"]),
                IdRadiologist = Convert.ToInt32(reader["IdRadiologist"]),
                TypeOfStudy = reader["TypeOfStudy"].ToString(),
                DateStudy = Convert.ToDateTime(reader["DateStudy"]),
                Volume = reader["Volume"] == DBNull.Value ? null : reader["Volume"].ToString(),
                Vascularization = reader["Vascularization"] == DBNull.Value ? null : reader["Vascularization"].ToString(),
                Echogenicity = reader["Echogenicity"] == DBNull.Value ? null : reader["Echogenicity"].ToString(),
                LymphNodeUltra = reader["LymphNodeUltra"] == DBNull.Value ? null : reader["LymphNodeUltra"].ToString(),
                ThyroglossalTractStudy = reader["ThyroglossalTractStudy"] == DBNull.Value ? null : reader["ThyroglossalTractStudy"].ToString(),
                Recommendation = reader["Recommendation"] == DBNull.Value ? null : reader["Recommendation"].ToString(),
                Nodules = new List<Nodule>() // Initialize Nodules list
            };

            // Check if NoduleId is DBNull before attempting to load Nodules
            if (reader["NoduleId"] != DBNull.Value)
            {
                // Load Nodules separately using NoduleRepository
                var noduleRepository = new NoduleRepository(_configuration); // Initialize NoduleRepository with IConfiguration
                var nodules = await noduleRepository.GetNodulesByStudyThyroidIdAsync(Convert.ToInt32(reader["NoduleId"]));
                foreach (var item in nodules)
                {
                    studyThyroid.Nodules.Add(item);
                }
            }

            return studyThyroid;

        }
    }
}
