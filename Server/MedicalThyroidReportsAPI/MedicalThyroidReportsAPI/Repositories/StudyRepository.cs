using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using MedicalThyroidReportsAPI.Modals;

namespace MedicalThyroidReportsAPI.Repositories
{
    public class StudyRepository
    {
        private readonly string _connectionString;

        public StudyRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public async Task<IEnumerable<Study>> GetAllStudiesAsync()
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = "SELECT * FROM Study";
            using var command = new MySqlCommand(query, connection);
            using var reader = await command.ExecuteReaderAsync();

            var studies = new List<Study>();
            while (await reader.ReadAsync())
            {
                studies.Add(MapToStudy(reader));
            }

            return studies;
        }

        public async Task<Study> GetStudyByIdAsync(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = "SELECT * FROM Study WHERE Id = @Id";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return MapToStudy(reader);
            }

            return null;
        }

        public async Task AddStudyAsync(Study study)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = "INSERT INTO Study (IdRadiologist, TypeOfStudy, DateStudy) VALUES (@IdRadiologist, @TypeOfStudy, @DateStudy)";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdRadiologist", study.IdRadiologist);
            command.Parameters.AddWithValue("@TypeOfStudy", study.TypeOfStudy);
            command.Parameters.AddWithValue("@DateStudy", study.DateStudy);

            await command.ExecuteNonQueryAsync();
        }

        public async Task UpdateStudyAsync(Study study)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = "UPDATE Study SET IdRadiologist = @IdRadiologist, TypeOfStudy = @TypeOfStudy, DateStudy = @DateStudy WHERE Id = @Id";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", study.Id);
            command.Parameters.AddWithValue("@IdRadiologist", study.IdRadiologist);
            command.Parameters.AddWithValue("@TypeOfStudy", study.TypeOfStudy);
            command.Parameters.AddWithValue("@DateStudy", study.DateStudy);

            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteStudyAsync(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = "DELETE FROM Study WHERE Id = @Id";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            await command.ExecuteNonQueryAsync();
        }

        private Study MapToStudy(IDataReader reader)
        {
            return new Study
            {
                Id = Convert.ToInt32(reader["Id"]),
                IdRadiologist = Convert.ToInt32(reader["IdRadiologist"]),
                TypeOfStudy = reader["TypeOfStudy"].ToString(),
                DateStudy = Convert.ToDateTime(reader["DateStudy"])
            };
        }
    }
}
