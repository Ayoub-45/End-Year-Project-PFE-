using MedicalThyroidReports.Modals;

using System;
using System.Collections.Generic;
using System.Data;
using MedicalThyroidReports.Modals;
using MySql.Data.MySqlClient;
using MySqlConnector;
using MySqlConnection = MySql.Data.MySqlClient.MySqlConnection;
using MySqlCommand = MySqlConnector.MySqlCommand;

namespace MedicalThyroidReports.Repositories
{
    public class PatientRepository
    {
        private readonly string _connectionString;

        public PatientRepository(IConfiguration configuration)
        {
            
            _connectionString = configuration.GetConnectionString("Default");
     
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();

            using (MySqlConnection  connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Patient";
              
                using (MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                {
                    connection.Open();
                    MySql.Data.MySqlClient.MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        patients.Add(new Patient
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Code = reader["Code"].ToString(),
                            Nom = reader["Nom"].ToString(),
                            Prenom = reader["Prenom"].ToString(),
                            Sexe = reader["Sexe"].ToString(),
                            Adresse = reader["Adresse"].ToString(),
                            Profession = reader["Profession"].ToString(),
                            Gs = reader["Gs"].ToString(),
                            Rh = Convert.ToByte(reader["Rh"]),
                            Race = reader["Race"].ToString(),
                            Poids = Convert.ToSingle(reader["Poids"]),
                            Taille = Convert.ToSingle(reader["Taille"]),
                            StatutMatrimonial = reader["StatutMatrimonial"].ToString(),
                            Date_Naissance = reader["Date_Naissance"].ToString()
                        });
                    }

                    reader.Close();
                }
            }

            return patients;
        }

        public async Task<int> AddPatientAsync(Patient patient)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Patient (Code, Nom, Prenom, Sexe, Adresse, 
                                                    Profession, Gs, Rh, Race, Poids, 
                                                    Taille, StatutMatrimonial,Date_Naissance) 
                                 VALUES (@Code, @Nom, @Prenom, @Sexe, @Adresse, 
                                         @Profession, @Gs, @Rh, @Race, @Poids, 
                                         @Taille, @StatutMatrimonial,@Date_Naissance);
                                 SELECT LAST_INSERT_ID();";

                using (MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Code", patient.Code);
                    command.Parameters.AddWithValue("@Nom", patient.Nom);
                    command.Parameters.AddWithValue("@Prenom", patient.Prenom);
                    command.Parameters.AddWithValue("@Sexe", patient.Sexe);
                    command.Parameters.AddWithValue("@Adresse", patient.Adresse);
                    command.Parameters.AddWithValue("@Profession", patient.Profession);
                    command.Parameters.AddWithValue("@Gs", patient.Gs);
                    command.Parameters.AddWithValue("@Rh", patient.Rh);
                    command.Parameters.AddWithValue("@Race", patient.Race);
                    command.Parameters.AddWithValue("@Poids", patient.Poids);
                    command.Parameters.AddWithValue("@Taille", patient.Taille);
                    command.Parameters.AddWithValue("@StatutMatrimonial", patient.StatutMatrimonial);
                    command.Parameters.AddWithValue("Date_Naissance", patient.Date_Naissance);

                    await connection.OpenAsync();
                    int newPatientId = Convert.ToInt32(await command.ExecuteScalarAsync());
                    return newPatientId;
                }
            }

        }
        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Patient WHERE Id = @Id";

                using (MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await connection.OpenAsync();
                    using (MySql.Data.MySqlClient.MySqlDataReader reader = (MySql.Data.MySqlClient.MySqlDataReader)await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {

                            return new Patient
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Code = reader["Code"].ToString(),
                                Nom = reader["Nom"].ToString(),
                                Prenom = reader["Prenom"].ToString(),
                                Sexe = reader["Sexe"].ToString(),
                                Adresse = reader["Adresse"].ToString(),
                                Profession = reader["Profession"].ToString(),
                                Gs = reader["Gs"].ToString(),
                                Rh = Convert.ToByte(reader["Rh"]),
                                Race = reader["Race"].ToString(),
                                Poids = Convert.ToSingle(reader["Poids"]),
                                Taille = Convert.ToSingle(reader["Taille"]),
                                StatutMatrimonial = reader["StatutMatrimonial"].ToString(),
                                Date_Naissance = Convert.ToDateTime(reader["Date_Naissance"]).ToString()
                            };
                        }
                        else
                        {
                            return null; // Patient not found
                        }
                    }
                }
            }
        }
        public async Task DeletePatientAsync(int id)
        {
            using (MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM Patient WHERE Id = @Id";

                using (MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE Patient 
                                 SET Code = @Code, 
                                     Nom = @Nom, 
                                     Prenom = @Prenom, 
                                     Sexe = @Sexe, 
                                     Adresse = @Adresse, 
                                     Profession = @Profession, 
                                     Gs = @Gs, 
                                     Rh = @Rh, 
                                     Race = @Race, 
                                     Poids = @Poids, 
                                     Taille = @Taille, 
                                     StatutMatrimonial = @StatutMatrimonial, 
                                     Date_Naissance = @Date_Naissance
                                 WHERE Id = @Id";

                using (MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", patient.Id);
                    command.Parameters.AddWithValue("@Code", patient.Code);
                    command.Parameters.AddWithValue("@Nom", patient.Nom);
                    command.Parameters.AddWithValue("@Prenom", patient.Prenom);
                    command.Parameters.AddWithValue("@Sexe", patient.Sexe);
                    command.Parameters.AddWithValue("@Adresse", patient.Adresse);
                    command.Parameters.AddWithValue("@Profession", patient.Profession);
                    command.Parameters.AddWithValue("@Gs", patient.Gs);
                    command.Parameters.AddWithValue("@Rh", patient.Rh);
                    command.Parameters.AddWithValue("@Race", patient.Race);
                    command.Parameters.AddWithValue("@Poids", patient.Poids);
                    command.Parameters.AddWithValue("@Taille", patient.Taille);
                    command.Parameters.AddWithValue("@StatutMatrimonial", patient.StatutMatrimonial);
                    command.Parameters.AddWithValue("@Date_Naissance", patient.Date_Naissance);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }


    }

}

