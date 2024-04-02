using System;
using System.Collections.Generic;
using MedicalThyroidReports.Modals;
using MySql.Data.MySqlClient;
using MySqlConnector;
using MySqlCommand = MySql.Data.MySqlClient.MySqlCommand;
namespace MedicalThyroidReports.Repositories
{
    public class PathologieRepository
    {
        private readonly string _connectionString;

        public PathologieRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        // Pathologie CRUD operations
        public Pathologie GetPathologieById(int id)
        {
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Pathologie p JOIN Specialite s ON p.IdSpecialite = s.Id WHERE p.Id = @Id";
                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Pathologie
                            {
                                Id = (int)reader["Id"],
                                Nom = (string)reader["Nom"],
                                IdSpecialite = (int)reader["IdSpecialite"],
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

        public IEnumerable<Pathologie> GetAllPathologies()
        {
            List<Pathologie> pathologies = new List<Pathologie>();
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Pathologie p JOIN Specialite s ON p.IdSpecialite = s.Id";
                using (var command = new MySqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pathologies.Add(new Pathologie
                            {
                                Id = (int)reader["Id"],
                                Nom = (string)reader["Nom"],
                                IdSpecialite = (int)reader["IdSpecialite"],

                            });
                        }
                    }
                }
            }
            return pathologies;
        }

        public void CreatePathologie(Pathologie pathologie)
        {
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Pathologie (Nom, IdSpecialite) VALUES (@Nom, @IdSpecialite)";
                using (var command = new MySql.Data.MySqlClient.MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Nom", pathologie.Nom);
                    command.Parameters.AddWithValue("@IdSpecialite", pathologie.IdSpecialite);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePathologie(Pathologie pathologie)
        {
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "UPDATE Pathologie SET Nom = @Nom, IdSpecialite = @IdSpecialite WHERE Id = @Id";
                using (var command = new MySql.Data.MySqlClient.MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", pathologie.Id);
                    command.Parameters.AddWithValue("@Nom", pathologie.Nom);
                    command.Parameters.AddWithValue("@IdSpecialite", pathologie.IdSpecialite);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeletePathologie(int id)
        {
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Pathologie WHERE Id = @Id";
                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Similar methods for Specialte CRUD operations
    }


}
