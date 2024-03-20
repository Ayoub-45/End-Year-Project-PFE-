
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

            var query = "INSERT INTO StudyThyroid (IdRadiologist, TypeOfStudy, DateStudy, Volume, Vascularization, Echogenicity, LymphNodeUltra, ThyroglossalTractStudy, Recommendation) " +
                        "VALUES (@IdRadiologist, @TypeOfStudy, @DateStudy, @Volume, @Vascularization, @Echogenicity, @LymphNodeUltra, @ThyroglossalTractStudy, @Recommendation)";
            using var command = new MySqlCommand(query, connection);
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

        public async Task UpdateStudyThyroidAsync(StudyThyroid studyThyroid)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            var query = "UPDATE StudyThyroid SET IdRadiologist = @IdRadiologist, TypeOfStudy = @TypeOfStudy, DateStudy = @DateStudy, " +
                        "Volume = @Volume, Vascularization = @Vascularization, Echogenicity = @Echogenicity, " +
                        "LymphNodeUltra = @LymphNodeUltra, ThyroglossalTractStudy = @ThyroglossalTractStudy, " +
                        "Recommendation = @Recommendation WHERE IdStudyThyroid = @IdStudyThyroid";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdStudyThyroid", studyThyroid.IdStudyThyroid);
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
                IdStudyThyroid = reader["IdStudyThyroid"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdStudyThyroid"]),
                Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0 : Convert.ToInt32(reader["Id"]),
                IdRadiologist = reader.IsDBNull(reader.GetOrdinal("IdRadiologist")) ? 0 : Convert.ToInt32(reader["IdRadiologist"]),
                TypeOfStudy = reader["TypeOfStudy"].ToString(),
                DateStudy = Convert.ToDateTime(reader["DateStudy"]),
                Volume = reader.IsDBNull(reader.GetOrdinal("Volume")) ? null : reader["Volume"].ToString(),
                Vascularization = reader.IsDBNull(reader.GetOrdinal("Vascularization")) ? null : reader["Vascularization"].ToString(),
                Echogenicity = reader.IsDBNull(reader.GetOrdinal("Echogenicity")) ? null : reader["Echogenicity"].ToString(),
                LymphNodeUltra = reader.IsDBNull(reader.GetOrdinal("LymphNodeUltra")) ? null : reader["LymphNodeUltra"].ToString(),
                ThyroglossalTractStudy = reader.IsDBNull(reader.GetOrdinal("ThyroglossalTractStudy")) ? null : reader["ThyroglossalTractStudy"].ToString(),
                Recommendation = reader.IsDBNull(reader.GetOrdinal("Recommendation")) ? null : reader["Recommendation"].ToString(),
            };


            return studyThyroid;
        }
        public List<StudyThyroid> GetAllStudyThyroidsWithNodules()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"
        SELECT s.*, n.*
        FROM StudyThyroid s
        LEFT JOIN Nodule n ON s.IdStudyThyroid = n.StudyThyroidId";

                var command = new MySqlCommand(query, connection);
                var reader = command.ExecuteReader();

                var studyThyroids = new Dictionary<int, StudyThyroid>();

                while (reader.Read())
                {
                    var studyThyroidId = reader.GetInt32(0); // Assuming IdStudyThyroid is the first column

                    if (!studyThyroids.ContainsKey(studyThyroidId))
                    {
                        var studyThyroid = new StudyThyroid
                        {
                            IdStudyThyroid = studyThyroidId,
                            Nodules = new List<Nodule>()
                        };
                        studyThyroids[studyThyroidId] = studyThyroid;
                    }

                    // Check if NoduleId is not null
                    if (!reader.IsDBNull(6)) // Assuming NoduleId is the seventh column
                    {
                        var nodule = new Nodule
                        {
                            IdNodule = reader.GetInt32(6), // Assuming NoduleId is the seventh column
                                                           // Populate other properties of Nodule here...
                        };
                        studyThyroids[studyThyroidId].Nodules.Add(nodule);
                    }
                }

                var result = studyThyroids.Values.ToList();
                return result;
            }
        }



    }

}
