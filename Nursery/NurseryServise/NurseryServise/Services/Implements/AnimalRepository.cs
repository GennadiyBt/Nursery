using NurseryServise.Models;
using System.Data.SQLite;

namespace NurseryServise.Services.Implements
{
    public class AnimalRepository : IAnimalRepository
    {
        private const string connectionString = "Data Source = nursery.db; Version = 3; Pooling = true; Max Pool Size = 100;";
        public int Create(Animal item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            try
            {
                connection.Open();
                // Прописываем в команду SQL-запрос на добавление данных
                SQLiteCommand command = new SQLiteCommand(connection);
                if (item.getTypId() == 1)
                {
                    switch (item.getKindId())
                    {
                        case 1: 
                            command.CommandText = "INSERT INTO dog(Name, Birthday, Kind_id) VALUES(@Name, @Birthday, @Kind_id)";
                            command.Parameters.AddWithValue("@SurName", item.getName());
                            command.Parameters.AddWithValue("@Birthday", item.getBirthDay().Ticks);
                            command.Parameters.AddWithValue("@Kind_id", item.getKindId());
                            // подготовка команды к выполнению
                            command.Prepare();
                            // Выполнение команды
                            return command.ExecuteNonQuery();
                        case 2:
                            command.CommandText = "INSERT INTO cat(Name, Birthday, Kind_id) VALUES(@Name, @Birthday, @Kind_id)";
                            command.Parameters.AddWithValue("@SurName", item.getName());
                            command.Parameters.AddWithValue("@Birthday", item.getBirthDay().Ticks);
                            command.Parameters.AddWithValue("@Kind_id", item.getKindId());
                            command.Prepare();
                            return command.ExecuteNonQuery();

                        case 3:
                            command.CommandText = "INSERT INTO hamster(Name, Birthday, Kind_id) VALUES(@Name, @Birthday, @Kind_id)";
                            command.Parameters.AddWithValue("@SurName", item.getName());
                            command.Parameters.AddWithValue("@Birthday", item.getBirthDay().Ticks);
                            command.Parameters.AddWithValue("@Kind_id", item.getKindId());
                            command.Prepare();
                            return command.ExecuteNonQuery();
                    }
                }
                else
                {
                    switch (item.getKindId())
                    {
                        case 1:
                            command.CommandText = "INSERT INTO hors(Name, Birthday, Kind_id) VALUES(@Name, @Birthday, @Kind_id)";
                            command.Parameters.AddWithValue("@SurName", item.getName());
                            command.Parameters.AddWithValue("@Birthday", item.getBirthDay().Ticks);
                            command.Parameters.AddWithValue("@Kind_id", item.getKindId());
                            command.Prepare();
                            return command.ExecuteNonQuery();
                        case 2:
                            command.CommandText = "INSERT INTO camel(Name, Birthday, Kind_id) VALUES(@Name, @Birthday, @Kind_id)";
                            command.Parameters.AddWithValue("@SurName", item.getName());
                            command.Parameters.AddWithValue("@Birthday", item.getBirthDay().Ticks);
                            command.Parameters.AddWithValue("@Kind_id", item.getKindId());
                            command.Prepare();
                            return command.ExecuteNonQuery();

                        case 3:
                            command.CommandText = "INSERT INTO donkey(Name, Birthday, Kind_id) VALUES(@Name, @Birthday, @Kind_id)";
                            command.Parameters.AddWithValue("@SurName", item.getName());
                            command.Parameters.AddWithValue("@Birthday", item.getBirthDay().Ticks);
                            command.Parameters.AddWithValue("@Kind_id", item.getKindId());
                            command.Prepare();
                            return command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
            return 0;
        }

        public int Delete(int type_id, int kind_id, int id)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            try
            {
                connection.Open();
                // Прописываем в команду SQL-запрос на добавление данных
                SQLiteCommand command = new SQLiteCommand(connection);
                if (type_id == 1)
                {
                    switch (kind_id)
                    {
                        case 1:
                            command.CommandText = "DELETE FROM dog WHERE Id=@Id";
                            command.Parameters.AddWithValue("@Id", id);
                            command.Prepare();
                            return command.ExecuteNonQuery();
                        case 2:
                            command.CommandText = "DELETE FROM cat WHERE Id=@Id";
                            command.Parameters.AddWithValue("@Id", id);
                            command.Prepare();
                            return command.ExecuteNonQuery();

                        case 3:
                            command.CommandText = "DELETE FROM hamster WHERE Id=@Id";
                            command.Parameters.AddWithValue("@Id", id);
                            command.Prepare();
                            return command.ExecuteNonQuery();
                    }
                }
                else
                {
                    switch (kind_id)
                    {
                        case 1:
                            command.CommandText = "DELETE FROM hors WHERE Id=@Id";
                            command.Parameters.AddWithValue("@Id", id);
                            command.Prepare();
                            return command.ExecuteNonQuery();
                        case 2:
                            command.CommandText = "DELETE FROM camel WHERE Id=@Id";
                            command.Parameters.AddWithValue("@Id", id);
                            command.Prepare();
                            return command.ExecuteNonQuery();

                        case 3:
                            command.CommandText = "DELETE FROM donkey WHERE Id=@Id";
                            command.Parameters.AddWithValue("@Id", id);
                            command.Prepare();
                            return command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
            return 0;
        }
    }

        public List<Animal> GetAll()
        {
        SQLiteConnection connection = new SQLiteConnection(connectionString);
        List<Client> list = new List<Client>();
        try
        {
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM clients";
            command.Prepare();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Client client = new Client
                {
                    ClientId = reader.GetInt32(0),
                    Document = reader.GetString(1),
                    SurName = reader.GetString(2),
                    FirstName = reader.GetString(3),
                    Patronymic = reader.GetString(4),
                    Birthday = new DateTime(reader.GetInt64(5))
                };

                list.Add(client);
            }
        }
        finally
        {
            connection.Close();
        }
        return list;
    }

        public Animal GetById(int animal_id)
        {
            throw new NotImplementedException();
        }

        public int Train(int animal_id)
        {
            throw new NotImplementedException();
        }
    }
}
