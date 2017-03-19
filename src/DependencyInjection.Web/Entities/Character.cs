namespace DependencyInjection.Web.Entities
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=IocLunchAndLearn;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
    public class Character
    {
        private static readonly string _table = "Characters";
        private static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=IocLunchAndLearn;
                    Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;
                    ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public string Name { get; set; }
        public int Id { get; set; }

        public static IList<Character> GetAll()
        {
            var characters = new List<Character>();
            
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand($"SELECT Id, Name FROM {_table}", connection);

                connection.Open();


                using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        var character = new Character
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };

                        characters.Add(character);
                    }
                }
                connection.Close();
            }
            return characters;
        }

        public static Character GetCharacter(int id)
        {
            var character = new Character();


            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand($"SELECT Id, Name FROM {_table} WHERE Id = {id}", connection);

                connection.Open();

                using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                        character = new Character
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };
                }

                connection.Close();
            }
            return character;
        }

        public static void Add(Character character)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand($"INSERT INTO {_table} (Name) VALUES ('{character.Name}')", connection);

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}