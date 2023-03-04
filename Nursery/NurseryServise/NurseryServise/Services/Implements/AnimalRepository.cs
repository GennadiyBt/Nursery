using Microsoft.Azure.Management.Storage.Fluent.Models;
using NurseryServise.Controllers;
using NurseryServise.Models;
using NurseryServise.Models.Designers;
using NurseryServise.Models.Skills;
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
                command.CommandText = "INSERT INTO " + item.kind + "(Name, Birthday, Kind_id) VALUES(@Name, @Birthday, @Kind_id)"; 
                command.Parameters.AddWithValue("@Name", item.getName());
                command.Parameters.AddWithValue("@Birthday", item.getBirthDay().Ticks);
                command.Parameters.AddWithValue("@Kind_id", item.getKindId());
                command.Prepare();
                return command.ExecuteNonQuery();
            }
            catch
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
        }

        public int Delete(Animal _animal)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "DELETE FROM "+ _animal.kind + " WHERE Id=@Id";
                command.Parameters.AddWithValue("@Id", _animal.getId());
                command.Prepare();
                return command.ExecuteNonQuery();
            }
            catch
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
        }


        public List<Animal> GetAll(string kind)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            List<Animal> list = new List<Animal>();
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "SELECT * FROM " + kind;
                command.Prepare();
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                     int Id = reader.GetInt32(0);
                     string name = reader.GetString(1);
                     DateTime Birthday = new DateTime(reader.GetInt64(2));
                     Animal animal = Constructor.createNewAnimal(kind, name, Birthday);
                     list.Add(animal);
                }
                return list;
            }
            finally
            {
                connection.Close();
            }
        }
        

        public Animal GetById(string kind, int id)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "SELECT * FROM " + kind +" WHERE Id=@Id";
                command.Parameters.AddWithValue("@Id", id);
                command.Prepare();
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read()) // Если удалось что-то прочитать
                {
                    // возвращаем прочитанное
                    string name = reader.GetString(1);
                    DateTime Birthday = new DateTime(reader.GetInt64(2));
                    Animal animal = Constructor.createNewAnimal(kind, name, Birthday);
                    animal.setId(id);
                    return animal;
                }
                else
                {
                    // Не нашлась запись по идентификатору
                    Console.WriteLine("Указанное животное отсутствует в базе.");
                    return null;
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public int Train(Animal trainingAnimal, ISkill _skill)
        {
            try
            {
                string listSkills = null;
                foreach (ISkill item in trainingAnimal.getSkills())
                {
                    if (_skill.Equals(item))
                    {
                        Console.WriteLine("Данное умение уже изучено");
                        return 1;
                    }
                }
                trainingAnimal.addSkill(_skill);
                
                listSkills +=", " + _skill.ToString();
                
                Console.WriteLine("Вы изучили новое умение");
                try
                {
                    // Вносим новое умение в базу
                    new SkillRepository().CreateSkill(_skill);
                }
                catch { Console.WriteLine("Данное умение уже есть в общей базе умений"); }

                finally
                {
                    SQLiteConnection connection = new SQLiteConnection(connectionString);
                    try
                    {
                        connection.Open();
                        // Добавляем новое умение в БД к записи животного
                        SQLiteCommand command = new SQLiteCommand(connection);
                        command.CommandText = "INSERT INTO " + trainingAnimal.kind + "(Commands) VALUES(@Commands)";
                        command.Parameters.AddWithValue("@Commands", listSkills);
                        command.Prepare();
                        command.ExecuteNonQuery();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                return 1;
            }
            catch 
            {
                return -1;
            }
        }

        public string GetSkills(Animal animal)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "SELECT * FROM " + animal.kind + " WHERE Id=@Id";
                command.Parameters.AddWithValue("@Id", animal.getId());
                command.Prepare();
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read()) // Если удалось что-то прочитать
                {
                    // возвращаем прочитанное
                    string listSkill = reader.GetString(3);
                    return listSkill;
                }
                else
                {
                    // Список умений пуст
                    return "У данного животного нет умений";
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
