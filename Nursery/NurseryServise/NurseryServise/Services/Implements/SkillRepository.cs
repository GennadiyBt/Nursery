using NurseryServise.Models.Skills;
using System.Data.SQLite;

namespace NurseryServise.Services.Implements
{
    public class SkillRepository : ISkillRepository
    {
        private const string connectionString = "Data Source = nursery.db; Version = 3; Pooling = true; Max Pool Size = 100;";

        public int CreateSkill(ISkill skill)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "INSERT INTO skills(Skill_name) VALUES (@Skill_name)";
                command.Parameters.AddWithValue("@Skill_name", skill.ToString());
                command.Prepare();
                return command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Данное умение уже есть в базе");
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }

        public int Delete(string name_skill)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "DELETE FROM skills WHERE Skill_name=@Skill_name";
                command.Parameters.AddWithValue("Skill_name", name_skill);
                command.Prepare();
                return command.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Skill> GetAll()
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            List<Skill> list = new List<Skill>();
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "SELECT * FROM skills";
                command.Prepare();
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Skill skill = new Skill
                    {
                        skill_name = reader.GetString(0)
                    };
                    list.Add(skill);
                }
            }
            finally
            {
                connection.Close();
            }
            return list;
        }

        public Skill GetByName(string name)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "SELECT * FROM skills WHERE Skill_name=@Skill_name";
                command.Parameters.AddWithValue("Skill_name", name);
                command.Prepare();
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Skill
                    {
                        skill_name = reader.GetString(0)
                    };
                }
                else
                {
                    Console.WriteLine("Данное умение в базе отсутствует");
                    return null;
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
