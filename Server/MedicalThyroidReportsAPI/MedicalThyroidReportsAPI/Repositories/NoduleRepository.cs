
using MySql.Data.MySqlClient;
using MedicalThyroidReportsAPI.Modals;
using System.Data;
using MySqlConnector;
using MySqlConnection = MySql.Data.MySqlClient.MySqlConnection;
using MySqlCommand = MySql.Data.MySqlClient.MySqlCommand;
using MySqlDataReader = MySql.Data.MySqlClient.MySqlDataReader;
namespace MedicalThyroidReportsAPI.Repositories
{
    public class NoduleRepository
    {
        private readonly string _connectionString;

        public NoduleRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public async Task<IEnumerable<Nodule>> GetAllNodulesAsync()
        {
            var nodules = new List<Nodule>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT * FROM Nodule";

                using (var command = new MySqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        nodules.Add(MapToNodule((MySqlDataReader)reader));
                    }
                }
            }

            return nodules;
        }

        public async Task<Nodule> GetNoduleByIdAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT * FROM Nodule WHERE idNodule = @Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapToNodule((MySqlDataReader)reader);
                        }
                    }
                }
            }

            return null;
        }

        public async Task AddNoduleAsync(Nodule nodule)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "INSERT INTO Nodule (Size, Location, Shape, Margin, Echogenicity, Composition, Clasifications, ExtraThyroidExtension, Catogrphy, Evolution, ScoreTirads) " +
                            "VALUES (@Size, @Location, @Shape, @Margin, @Echogenicity, @Composition, @Clasifications, @ExtraThyroidExtension, @Catogrphy, @Evolution, @ScoreTirads)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Size", nodule.Size);
                    command.Parameters.AddWithValue("@Location", nodule.Location);
                    command.Parameters.AddWithValue("@Shape", nodule.Shape);
                    command.Parameters.AddWithValue("@Margin", nodule.Margin);
                    command.Parameters.AddWithValue("@Echogenicity", nodule.Echogenicity);
                    command.Parameters.AddWithValue("@Composition", nodule.Composition);
                    command.Parameters.AddWithValue("@Clasifications", nodule.Clasifications);
                    command.Parameters.AddWithValue("@ExtraThyroidExtension", nodule.ExtraThyroidExtension);
                    command.Parameters.AddWithValue("@Catogrphy", nodule.Catogrphy);
                    command.Parameters.AddWithValue("@Evolution", nodule.Evolution);
                    command.Parameters.AddWithValue("@ScoreTirads", nodule.ScoreTirads);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateNoduleAsync(Nodule nodule)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "UPDATE Nodule SET Size = @Size, Location = @Location, Shape = @Shape, Margin = @Margin, " +
                            "Echogenicity = @Echogenicity, Composition = @Composition, Clasifications = @Clasifications, " +
                            "ExtraThyroidExtension = @ExtraThyroidExtension, Catogrphy = @Catogrphy, Evolution = @Evolution, " +
                            "ScoreTirads = @ScoreTirads WHERE idNodule = @Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Size", nodule.Size);
                    command.Parameters.AddWithValue("@Location", nodule.Location);
                    command.Parameters.AddWithValue("@Shape", nodule.Shape);
                    command.Parameters.AddWithValue("@Margin", nodule.Margin);
                    command.Parameters.AddWithValue("@Echogenicity", nodule.Echogenicity);
                    command.Parameters.AddWithValue("@Composition", nodule.Composition);
                    command.Parameters.AddWithValue("@Clasifications", nodule.Clasifications);
                    command.Parameters.AddWithValue("@ExtraThyroidExtension", nodule.ExtraThyroidExtension);
                    command.Parameters.AddWithValue("@Catogrphy", nodule.Catogrphy);
                    command.Parameters.AddWithValue("@Evolution", nodule.Evolution);
                    command.Parameters.AddWithValue("@ScoreTirads", nodule.ScoreTirads);
                    command.Parameters.AddWithValue("@Id", nodule.idNodule);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteNoduleAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "DELETE FROM Nodule WHERE idNodule = @Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task<IEnumerable<Nodule>> GetNodulesByStudyThyroidIdAsync(int studyThyroidId)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = "SELECT * FROM Nodule WHERE StudyThyroidId = @StudyThyroidId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudyThyroidId", studyThyroidId);

            using var reader = await command.ExecuteReaderAsync();

            var nodules = new List<Nodule>();
            while (await reader.ReadAsync())
            {
                nodules.Add(MapToNodule((MySqlDataReader) reader));
            }

            return nodules;
        }

        
        private Nodule MapToNodule(MySqlDataReader reader)
        { 
            return new Nodule
            {
                idNodule = reader.GetInt32("idNodule"),
                Size = reader.GetString("Size"),
                Location = reader.GetString("Location"),
                Shape = reader.GetString("Shape"),
                Margin = reader.GetString("Margin"),
                Echogenicity = reader.GetString("Echogenicity"),
                Composition = reader.GetString("Composition"),
                Clasifications = reader.GetString("Clasifications"),
                ExtraThyroidExtension = reader.GetString("ExtraThyroidExtension"),
                Catogrphy = reader.GetString("Catogrphy"),
                Evolution = reader.GetString("Evolution"),
                ScoreTirads = reader.GetInt32("ScoreTirads")
            };
        }
    }
}

