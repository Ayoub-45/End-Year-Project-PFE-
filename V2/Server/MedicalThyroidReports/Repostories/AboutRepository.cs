using MedicalThyroidReports.Modals;

namespace MedicalThyroidReports.Repostories
{
    public class AboutRepository
    {
        public string _connectionString;
        AboutRepository(IConfiguration configuration) {
            _connectionString = configuration.GetConnectionString("Default");
        }
        //Perform the CRUD Operations for About content
        public About GetAboutById(int id)
        {
            using(var connection= new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM About WHERE Id=@Id";
                using(var command=new MySql.Data.MySqlClient.MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader=command.ExecuteReader())
                    {
                     if(reader.Read())
                        {
                            return new About
                            {
                                Id = (int)reader["Id"],
                                Content = (string)reader["Content"],
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

    }
}
