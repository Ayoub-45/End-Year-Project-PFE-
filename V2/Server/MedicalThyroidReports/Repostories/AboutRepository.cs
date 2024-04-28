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
        public List<About> GetAllAbouts()
        {
            List<About> Abouts=new List<About>();
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM About";
                using (var command=new MySql.Data.MySqlClient.MySqlCommand(sql,connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Abouts.Add(new About
                            {
                                Id = (int)reader["Id"],
                                Content = (string)reader["Content"]
                            });
                        }
                    }
                }

            }
        return Abouts;
        }

    public void CreateAbout(About about)
        {
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO About (Content) VALUES(@Content)";
                using (var command=new MySql.Data.MySqlClient.MySqlCommand(sql,connection))
                {
                    command.Parameters.AddWithValue("@Content", about.Content);
                    command.ExecuteNonQuery();

                }
            }
        }
    public void UpdateAbout(About about)
        {
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "UPDATE About SET Content=@Content WHERE Id=@Id";
                using (var command=new MySql.Data.MySqlClient.MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", about.Id);
                    command.Parameters.AddWithValue("@Content", about.Content);
                    command.ExecuteNonQuery();
                }
            }
        }
     public void DeleteAbout(int id)
        {
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM About WHERE Id=@Id";
                using (var command = new MySql.Data.MySqlClient.MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                } ;
            }
                    
        }

    }

}
