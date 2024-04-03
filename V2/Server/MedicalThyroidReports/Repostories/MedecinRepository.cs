using MedicalThyroidReports.Modals;
using MySql.Data.MySqlClient;

namespace MedicalThyroidReports.Repostories
{
    public class MedecinRepository
    {
     
            private readonly string _connectionString;

            public MedecinRepository(IConfiguration configuration)
            {
                _connectionString = configuration.GetConnectionString("Default");
            }

            public async Task<Medecin> GetByIdAsync(int id)
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Medecin WHERE Id = @Id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                return new Medecin
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Prenom = reader["Prenom"].ToString(),
                                    Nom = reader["Nom"].ToString(),
                                    IdSpecialite = Convert.ToInt32(reader["IdSpecialite"]),
                                    Grade = reader["Grade"].ToString()
                                };
                            }
                        }
                    }
                }
                return null;
            }

            public async Task<List<Medecin>> GetAllAsync()
            {
                List<Medecin> medecins = new List<Medecin>();
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Medecin";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                medecins.Add(new Medecin
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Prenom = reader["Prenom"].ToString(),
                                    Nom = reader["Nom"].ToString(),
                                    IdSpecialite = Convert.ToInt32(reader["IdSpecialite"]),
                                    Grade = reader["Grade"].ToString()
                                });
                            }
                        }
                    }
                }
                return medecins;
            }

            public async Task<Medecin> CreateAsync(Medecin medecin)
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Medecin (Prenom, Nom, IdSpecialite, Grade) VALUES (@Prenom, @Nom, @IdSpecialite, @Grade); SELECT LAST_INSERT_ID();";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Prenom", medecin.Prenom);
                        command.Parameters.AddWithValue("@Nom", medecin.Nom);
                        command.Parameters.AddWithValue("@IdSpecialite", medecin.IdSpecialite);
                        command.Parameters.AddWithValue("@Grade", medecin.Grade);
                        medecin.Id = Convert.ToInt32(await command.ExecuteScalarAsync());
                    }
                }
                return medecin;
            }

            public async Task UpdateAsync(Medecin medecin)
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Medecin SET Prenom = @Prenom, Nom = @Nom, IdSpecialite = @IdSpecialite, Grade = @Grade WHERE Id = @Id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", medecin.Id);
                        command.Parameters.AddWithValue("@Prenom", medecin.Prenom);
                        command.Parameters.AddWithValue("@Nom", medecin.Nom);
                        command.Parameters.AddWithValue("@IdSpecialite", medecin.IdSpecialite);
                        command.Parameters.AddWithValue("@Grade", medecin.Grade);
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }

            public async Task DeleteAsync(int id)
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Medecin WHERE Id = @Id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
        }

    }
