using System.Data.SQLite;

namespace NurseryServise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Процедура создания БД, таблиц, заполнение базовых. Процедура проводится при отсутствии БД
            //ConfigureSqlLiteConnection();
        }

        private static void ConfigureSqlLiteConnection()
        {
            const string connectionString = "Data Source = nursery.db; Version = 3; Pooling = true; Max Pool Size = 100;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            PrepareScheme(connection);
        }


        //  Метод для создания таблиц в базе данных, заполнения базовых таблиц. Вызывается единожды при первом запуске программы.
        // При подключении к существующей БД - не используется.
        private static void PrepareScheme(SQLiteConnection connection)
        {
            SQLiteCommand command = new SQLiteCommand(connection);

            command.CommandText = "DROP TABLE IF EXISTS animals_type";
            command.ExecuteNonQuery();

            command.CommandText = "DROP TABLE IF EXISTS home_animals";
            command.ExecuteNonQuery();
            command.CommandText = "DROP TABLE IF EXISTS beast_of_burden";
            command.ExecuteNonQuery();
            command.CommandText = "DROP TABLE IF EXISTS dog";
            command.ExecuteNonQuery();
            command.CommandText = "DROP TABLE IF EXISTS cat";
            command.ExecuteNonQuery();
            command.CommandText = "DROP TABLE IF EXISTS hamster";
            command.ExecuteNonQuery();
            command.CommandText = "DROP TABLE IF EXISTS hors";
            command.ExecuteNonQuery();
            command.CommandText = "DROP TABLE IF EXISTS camel";
            command.ExecuteNonQuery();
            command.CommandText = "DROP TABLE IF EXISTS donkey";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE animals_type( Id INTEGER PRIMARY KEY,
                    Type_name VARCHAR(20) );";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE home_animals( Id INTEGER PRIMARY KEY,
                    Kind_name VARCHAR(20),
                    Type_id INT,
                    FOREIGN KEY (Type_id) REFERENCES animals_type (Id) ON DELETE CASCADE ON UPDATE CASCADE );";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE BEAST_OF_BURDEN( Id INTEGER PRIMARY KEY,
                    Kind_name VARCHAR(20),
                    Type_id INT,
                    FOREIGN KEY (Type_id) REFERENCES animals_type (Id) ON DELETE CASCADE ON UPDATE CASCADE );";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE dog (Id INTEGER PRIMARY KEY, 
                    Name VARCHAR(20), 
                    Birthday DATE,
                    Commands VARCHAR(50),
                    Kind_id int,
                    Foreign KEY (Kind_id) REFERENCES home_animals (Id) ON DELETE CASCADE ON UPDATE CASCADE);";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE cat(Id INTEGER PRIMARY KEY, 
                    Name VARCHAR(20), 
                    Birthday DATE,
                    Commands VARCHAR(50),
                    Kind_id int,
                    Foreign KEY (Kind_id) REFERENCES home_animals (Id) ON DELETE CASCADE ON UPDATE CASCADE);";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE hamster (Id INTEGER PRIMARY KEY, 
                    Name VARCHAR(20), 
                    Birthday DATE,
                    Commands VARCHAR(50),
                    Kind_id int,
                    Foreign KEY (Kind_id) REFERENCES home_animals (Id) ON DELETE CASCADE ON UPDATE CASCADE);";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE hors (Id INTEGER PRIMARY KEY, 
                    Name VARCHAR(20), 
                    Birthday DATE,
                    Commands VARCHAR(50),
                    Kind_id int,
                    Foreign KEY (Kind_id) REFERENCES beast_of_burden (Id) ON DELETE CASCADE ON UPDATE CASCADE);";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE camel (Id INTEGER PRIMARY KEY, 
                    Name VARCHAR(20), 
                    Birthday DATE,
                    Commands VARCHAR(50),
                    Kind_id int,
                    Foreign KEY (Kind_id) REFERENCES beast_of_burden (Id) ON DELETE CASCADE ON UPDATE CASCADE);";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE donkey (Id INT PRIMARY KEY, 
                    Name VARCHAR(20), 
                    Birthday DATE,
                    Commands VARCHAR(50),
                    Kind_id int,
                    Foreign KEY (Kind_id) REFERENCES beast_of_burden (Id) ON DELETE CASCADE ON UPDATE CASCADE);";
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