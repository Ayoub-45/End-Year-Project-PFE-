using MedicalThyroidReports.Modals;
using MySql.Data.MySqlClient;
using MySqlConnector;

namespace MedicalThyroidReports.Repostories
{
    public class SpecialiteRepository
    {
        private readonly string _connectionString;

        public SpecialiteRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        // CRUD operations for Specialte

        public Specialite GetSpecialteById(int id)
        {
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Specialite WHERE Id = @Id";
                using (var command = new MySql.Data.MySqlClient.MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {   

                        if (reader.Read())
                        {
                            return new Specialite
                            {
                                Id = (int)reader["Id"],
                                Nom = (string)reader["Nom"],
                              


                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
public List<Specialite> GetAllSpecialtes()
        {
            List<Specialite> specialtes = new List<Specialite>();
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Specialite";
                using (var command = new MySql.Data.MySqlClient.MySqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            specialtes.Add(new Specialite
                            {
                                Id = (int)reader["Id"],
                                Nom = (string)reader["Nom"]
                            });
                        }
                    }
                }
            }
            return specialtes;
        }

        public void CreateSpecialite(Specialite specialite)
        {
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO specialite (Nom) VALUES (@Nom)";
                using (var command = new MySql.Data.MySqlClient.MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Nom", specialite.Nom);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateSpecialte(Specialite specialte)
        {
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "UPDATE Specialte SET Nom = @Nom WHERE Id = @Id";
                using (var command = new MySql.Data.MySqlClient.MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", specialte.Id);
                    command.Parameters.AddWithValue("@Nom", specialte.Nom);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteSpecialte(int id)
        {
            // Handle potential foreign key constraints
            if (_HasDependentPathologies(id))
            {
                throw new Exception("Cannot delete Specialite with ID: " + id + ". Foreign key constraint violation.");
            }

            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Specialite WHERE Id = @Id";
                using (var command = new MySql.Data.MySqlClient.MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private bool _HasDependentPathologies(int specialiteId)
        {
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString)) // Assuming SqlConnection for your database
            {
                connection.Open();
                string sql = "SELECT COUNT(*) FROM Pathologie WHERE IdSpecialite = @Id";
                using (var command = new MySql.Data.MySqlClient.MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", specialiteId);
                    long count = (long)command.ExecuteScalar(); // Explicit cast to long
                    return count > 0;
                }
            }
        }

    }
}
