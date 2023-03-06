using NurseryConsole.Controllers;
using NurseryConsole.Services.Implements;
using NurseryConsole.UserInterfase;
using System.Data.SQLite;

namespace NurseryConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Процедура создания БД, таблиц, заполнение базовых. Процедура проводится при отсутствии БД
            ConfigureSqlLiteConnection();
            AnimalRepository _animalRepositori = new AnimalRepository();
            AnimalController _animalController = new AnimalController(_animalRepositori);
            new Menu(_animalController).start();
        }

        private static void ConfigureSqlLiteConnection()
        {
            const string connectionString = "Data Source = D:\\Итоговый проект\\Nursery\\NurseryServise\\NurseryConsole\\DataBase\\NurseryServise.db; Version = 3; Pooling = true; Max Pool Size = 100;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            PrepareScheme(connection);
        }


        //  Метод для создания таблиц в базе данных, заполнения базовых таблиц. Вызывается единожды при первом запуске программы.
        // При подключении к существующей БД - не используется.
        private static void PrepareScheme(SQLiteConnection connection)
        {
            SQLiteCommand command = new SQLiteCommand(connection);



            command.CommandText = @"CREATE TABLE animals_type( Id INTEGER PRIMARY KEY,
                    Type_name TEXT );";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE home_animals( Id INTEGER PRIMARY KEY,
                    Kind_name TEXT,
                    Type_id INTEGER,
                    FOREIGN KEY (Type_id) REFERENCES animals_type (Id) ON DELETE CASCADE ON UPDATE CASCADE );";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE BEAST_OF_BURDEN( Id INTEGER PRIMARY KEY,
                    Kind_name TEXT,
                    Type_id INTEGER,
                    FOREIGN KEY (Type_id) REFERENCES animals_type (Id) ON DELETE CASCADE ON UPDATE CASCADE );";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE dog (Id INTEGER PRIMARY KEY, 
                    Name TEXT, 
                    Birthday INTEGER,
                    Commands TEXT,
                    Kind_id INTEGER,
                    Foreign KEY (Kind_id) REFERENCES home_animals (Id) ON DELETE CASCADE ON UPDATE CASCADE);";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE cat(Id INTEGER PRIMARY KEY, 
                    Name TEXT, 
                    Birthday INTEGER,
                    Commands TEXT,
                    Kind_id INTEGER,
                    Foreign KEY (Kind_id) REFERENCES home_animals (Id) ON DELETE CASCADE ON UPDATE CASCADE);";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE hamster (Id INTEGER PRIMARY KEY, 
                    Name TEXT, 
                    Birthday INTEGER,
                    Commands TEXT,
                    Kind_id INTEGER,
                    Foreign KEY (Kind_id) REFERENCES home_animals (Id) ON DELETE CASCADE ON UPDATE CASCADE);";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE hors (Id INTEGER PRIMARY KEY, 
                    Name TEXT, 
                    Birthday INTEGER,
                    Commands TEXT,
                    Kind_id INTEGER,
                    Foreign KEY (Kind_id) REFERENCES beast_of_burden (Id) ON DELETE CASCADE ON UPDATE CASCADE);";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE camel (Id INTEGER PRIMARY KEY, 
                    Name TEXT, 
                    Birthday INTEGER,
                    Commands TEXT,
                    Kind_id INTEGER,
                    Foreign KEY (Kind_id) REFERENCES beast_of_burden (Id) ON DELETE CASCADE ON UPDATE CASCADE);";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE donkey (Id INTEGER PRIMARY KEY, 
                    Name TEXT, 
                    Birthday INTEGER,
                    Commands TEXT,
                    Kind_id INTEGER,
                    Foreign KEY (Kind_id) REFERENCES beast_of_burden (Id) ON DELETE CASCADE ON UPDATE CASCADE);";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE skills (Skill_name TEXT PRIMARY KEY);";
            command.ExecuteNonQuery();

            command.CommandText = @"INSERT INTO animals_type (Type_name)
                    VALUES (""домашние""),
                    (""вьючные"");";
            command.ExecuteNonQuery();

            command.CommandText = @"INSERT INTO home_animals (Kind_name, Type_id)
                    VALUES (""Собака"", 1),
                    (""Кошка"", 1),  
                    (""Хомяк"", 1);";
            command.ExecuteNonQuery();

            command.CommandText = @"INSERT INTO beast_of_burden (Kind_name, Type_id)
                    VALUES (""Лошадь"", 2),
                    (""Верблюд"", 2),  
                    (""Осел"", 2);";
            command.ExecuteNonQuery();

            connection.Close();
        }



    }
}