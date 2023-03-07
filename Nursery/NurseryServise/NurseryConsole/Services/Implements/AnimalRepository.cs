using NurseryConsole.Models;
using NurseryConsole.Models.Desingers;
using NurseryConsole.Models.Skills;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryConsole.Services.Implements
{
    public class AnimalRepository : IAnimalRepository
    {
        private const string connectionString = "Data Source = D:\\Итоговый проект\\Nursery\\NurseryServise\\NurseryConsole\\DataBase\\NurseryServise.db; Version = 3; Pooling = true; Max Pool Size = 100;";
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
                command.CommandText = "DELETE FROM " + _animal.kind + " WHERE Id=@Id";
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


        public List<Animal> GetAllofKind(string kind)
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
                    animal.setId(Id);
                    list.Add(animal);
                }
                if (list.Count == 0) { Console.WriteLine("Животные данного вида в базе отсутствуют"); }
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
                command.CommandText = "SELECT * FROM " + kind + " WHERE Id=@Id";
                command.Parameters.AddWithValue("@Id", id);
                command.Prepare();
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read()) // Если удалось что-то прочитать
                {
                    // возвращаем прочитанное
                    string name = reader.GetString(1);
                    DateTime Birthday = new DateTime(reader.GetInt64(2));
                    Animal animal = Constructor.createNewAnimal(kind, name, Birthday);
                    // Вытащить список скилов как строку, разбить по пробелам, создать объекты скилов и сложить в список
                    try
                    {
                        string skill = reader.GetString(3);
                        string[] skillList = skill.Split("");
                        for (int i = 0; i < skillList.Length; i++)
                        {
                            ISkill newSkill = new Skill(skillList[i]);
                            animal.addSkill(newSkill);
                        }
                    }
                    catch { Console.WriteLine("У данного животного умения отсутствуют"); }

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

        public int Train(Animal trainingAnimal, ISkill _skill, string listSkills)
        {
            try
            {               
                foreach (ISkill item in trainingAnimal.getSkills())
                {
                    Console.WriteLine("Point1");
                    if (_skill.Equals(item))
                    {
                        Console.WriteLine("Данное умение уже изучено");
                        return 1;
                    }
                }
                trainingAnimal.addSkill(_skill);
                listSkills += (" " +_skill.ToString());

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
                    Console.WriteLine(listSkills);
                    try
                    {
                        connection.Open();
                        // Добавляем новое умение в БД к записи животного
                        SQLiteCommand command = new SQLiteCommand(connection);
                        command.CommandText = "UPDATE " + trainingAnimal.kind + " SET Commands = @Commands WHERE Id=@Id ";
                        command.Parameters.AddWithValue("@Commands", listSkills);
                        command.Parameters.AddWithValue("@Id", trainingAnimal.getId());
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

            catch (Exception)
            {
                return -1;
            }
        }
        
        public void GetAll()
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "SELECT h.Name, h.Birthday, bob.Kind_name FROM hors h " +
                    "LEFT JOIN beast_of_burden bob ON h.kind_id = bob.id UNION " +
                    "SELECT c.Name, c.Birthday, bob.Kind_name FROM camel c LEFT JOIN beast_of_burden bob ON c.kind_id = bob.id " +
                    "UNION SELECT d.Name, d.Birthday, bob.Kind_name FROM donkey d LEFT JOIN beast_of_burden bob ON d.kind_id = bob.id " +
                    "UNION SELECT h.Name, h.Birthday, ha.Kind_name FROM hamster h LEFT JOIN home_animals ha ON h.kind_id = ha.id " +
                    "UNION SELECT d.Name, d.Birthday, ha.Kind_name FROM dog d LEFT JOIN home_animals ha ON d.kind_id = ha.id " +
                    "UNION SELECT c.Name, c.Birthday, ha.Kind_name FROM cat c LEFT JOIN home_animals ha ON c.kind_id = ha.id";
                command.Prepare();
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0) +", "+ new DateTime(reader.GetInt64(1)).ToShortDateString() +", "+ reader.GetString(2));
                }
            }
            finally { connection.Close(); }
        }
    }
}
