using System;
using System.Data;
using System.Data.Common;
using MedicalThyroidReportsAPI.Modals;
using MySql.Data.MySqlClient;
using MySqlConnector;

namespace MedicalThyroidReportsAPI.Repositories
{
    public class PatientRepository
    {
        private readonly string _connectionString;

        public PatientRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }
        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            var patients = new List<Patient>();
            try

            {

            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
       
                await connection.OpenAsync();
                var query = "SELECT * FROM patients";

                using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        patients.Add(MapToPatient(reader));
                    }
                }
            }


            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
   
            }
            return patients;
        }
        public List<Patient> GetAllPatientsWithStudies()
        {
            List<Patient> patients = new List<Patient>();

            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"
            SELECT p.*, s.*
            FROM patients p
            LEFT JOIN study s ON p.IdPatient = s.PatientId";

                using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int patientId = reader.GetInt32("IdPatient");

                        // Check if patient already exists in the list
                        Patient patient = patients.FirstOrDefault(p => p.IdPatient == patientId);
                        if (patient == null)
                        {
                            // Create a new patient object
                            Patient p= new Patient
                            {
                                IdPatient = patientId,
                                CodePatient = reader.GetInt32("CodePatient"),
                                FirstNamePatient = reader.GetString("FirstNamePatient"),
                                MiddleNamePatient = reader.IsDBNull("MiddleNamePatient") ? null : reader.GetString("MiddleNamePatient"),
                                LastNamePatient = reader.GetString("LastNamePatient"),
                                DateOfBirth = reader.GetDateTime("DateOfBirth"),
                                PhonePatient = reader.GetString("PhonePatient"),
                                AddressPatient = reader.GetString("AddressPatient"),
                                CityPatient = reader.GetString("CityPatient"),
                                CountryPatient = reader.GetString("CountryPatient"),
                                SexPatient = reader.GetString("SexPatient"),
                                Studies = new List<Study>() // Initialize Studies as an empty list
                            };


                            patients.Add(p);
                        }

                        // Add study to patient's studies list
                        Study study = new Study
                        {
                            Id = reader.GetInt32("Id"),
                            IdRadiologist = reader.GetInt32("IdRadiologist"),
                            TypeOfStudy = reader.GetString("TypeOfStudy"),
                            DateStudy = reader.GetDateTime("DateStudy")
                        };
                        patient.Studies.Add(study);
                    }
                }
            }

            return patients;
        }

        private Patient MapToPatient(DbDataReader reader)
        {
            return new Patient
            {
                IdPatient = reader.GetInt32("IdPatient"),
                CodePatient = reader.GetInt32("CodePatient"),
                FirstNamePatient = reader.GetString("FirstNamePatient"),
                MiddleNamePatient = reader.IsDBNull(reader.GetOrdinal("MiddleNamePatient")) ? null : reader.GetString("MiddleNamePatient"),
                LastNamePatient = reader.GetString("LastNamePatient"),
                DateOfBirth = reader.GetDateTime("DateOfBirth").Date,
                PhonePatient = reader.GetString("PhonePatient"),
                AddressPatient = reader.GetString("AddressPatient"),
                CityPatient = reader.GetString("CityPatient"),
                CountryPatient = reader.GetString("CountryPatient"),
                SexPatient = reader.GetString("SexPatient")
            };
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT * FROM Patients WHERE IdPatient = @Id";

                using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapToPatient(reader);
                        }
                    }
                }
            }

            return null;
        }

        public async Task AddPatientAsync(Patient patient)
        {
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
               await  connection.OpenAsync();

                var query = "INSERT INTO Patients (CodePatient, FirstNamePatient, MiddleNamePatient, LastNamePatient, DateOfBirth, PhonePatient, AddressPatient, CityPatient, CountryPatient, SexPatient) " +
                            "VALUES (@Code, @FirstName, @MiddleName, @LastName, @DateOfBirth, @Phone, @Address, @City, @Country, @Sex)";

                using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Code", patient.CodePatient);
                    command.Parameters.AddWithValue("@FirstName", patient.FirstNamePatient);
                    command.Parameters.AddWithValue("@MiddleName", (object)patient.MiddleNamePatient ?? DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", patient.LastNamePatient);
                    command.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                    command.Parameters.AddWithValue("@Phone", patient.PhonePatient);
                    command.Parameters.AddWithValue("@Address", patient.AddressPatient);
                    command.Parameters.AddWithValue("@City", patient.CityPatient);
                    command.Parameters.AddWithValue("@Country", patient.CountryPatient);
                    command.Parameters.AddWithValue("@Sex", patient.SexPatient);

                    await command.ExecuteNonQueryAsync();
                    

                }
            }
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "UPDATE Patients SET CodePatient = @Code, FirstNamePatient = @FirstName, MiddleNamePatient = @MiddleName, " +
                            "LastNamePatient = @LastName, DateOfBirth = @DateOfBirth, PhonePatient = @Phone, AddressPatient = @Address, " +
                            "CityPatient = @City, CountryPatient = @Country, SexPatient = @Sex WHERE IdPatient = @Id";

                using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", patient.IdPatient);
                    command.Parameters.AddWithValue("@Code", patient.CodePatient);
                    command.Parameters.AddWithValue("@FirstName", patient.FirstNamePatient);
                    command.Parameters.AddWithValue("@MiddleName", (object) patient.MiddleNamePatient ?? DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", patient.LastNamePatient);
                    command.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                    command.Parameters.AddWithValue("@Phone", patient.PhonePatient);
                    command.Parameters.AddWithValue("@Address", patient.AddressPatient);
                    command.Parameters.AddWithValue("@City", patient.CityPatient);
                    command.Parameters.AddWithValue("@Country", patient.CountryPatient);
                    command.Parameters.AddWithValue("@Sex", patient.SexPatient);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeletePatientAsync(int id)
        {
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "DELETE FROM Patients WHERE IdPatient = @Id";

                using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

    }
}
