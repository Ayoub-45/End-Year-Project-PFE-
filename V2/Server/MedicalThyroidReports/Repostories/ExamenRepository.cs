using MedicalThyroidReports.Modals;
using MySql.Data.MySqlClient;
using MySqlConnector;
namespace MedicalThyroidReports.Repositories
{

public class ExamenRepository
{
    private readonly string _connectionString;

    public ExamenRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Default");
    }

    public async Task<Examen> GetByIdAsync(long id)
    {
        using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Examen WHERE Id = @Id";
            using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        return new Examen
                        {
                            Id = Convert.ToInt64(reader["Id"]),
                            IdPatient = Convert.ToInt64(reader["IdPatient"]),
                            IdPathologie = Convert.ToInt64(reader["IdPathologie"]),
                            IdMedecin = Convert.ToInt64(reader["IdMedecin"]),
                            Date_Examen = reader["Date_Examen"].ToString()
                        };
                    }
                }
            }
        }
        return null;
    }

    public async Task<List<Examen>> GetAllAsync()
    {
        List<Examen> examens = new List<Examen>();
        using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Examen";
            using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        examens.Add(new Examen
                        {
                            Id = Convert.ToInt64(reader["Id"]),
                            IdPatient = Convert.ToInt64(reader["IdPatient"]),
                            IdPathologie = Convert.ToInt64(reader["IdPathologie"]),
                            IdMedecin = Convert.ToInt64(reader["IdMedecin"]),
                            Date_Examen = reader["Date_Examen"].ToString()
                        });
                    }
                }
            }
        }
        return examens;
    }

    public async Task<Examen> CreateAsync(Examen examen)
    {
        using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Examen (IdPatient, IdPathologie, IdMedecin, Date_Examen) VALUES (@IdPatient, @IdPathologie, @IdMedecin, @Date_Examen); SELECT LAST_INSERT_ID();";
            using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdPatient", examen.IdPatient);
                command.Parameters.AddWithValue("@IdPathologie", examen.IdPathologie);
                command.Parameters.AddWithValue("@IdMedecin", examen.IdMedecin);
                command.Parameters.AddWithValue("@Date_Examen", examen.Date_Examen);
                examen.Id = Convert.ToInt64(await command.ExecuteScalarAsync());
            }
        }
        return examen;
    }

    public async Task UpdateAsync(Examen examen)
    {
        using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
        {
            connection.Open();
            string query = "UPDATE Examen SET IdPatient = @IdPatient, IdPathologie = @IdPathologie, IdMedecin = @IdMedecin, Date_Examen = @Date_Examen WHERE Id = @Id";
            using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", examen.Id);
                command.Parameters.AddWithValue("@IdPatient", examen.IdPatient);
                command.Parameters.AddWithValue("@IdPathologie", examen.IdPathologie);
                command.Parameters.AddWithValue("@IdMedecin", examen.IdMedecin);
                command.Parameters.AddWithValue("@Date_Examen", examen.Date_Examen);
                await command.ExecuteNonQueryAsync();
            }
        }
    }

    public async Task DeleteAsync(long id)
    {
        using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
        {
            connection.Open();
            string query = "DELETE FROM Examen WHERE Id = @Id";
            using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
}

