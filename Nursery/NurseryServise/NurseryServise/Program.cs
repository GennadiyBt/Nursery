using System.Data.SQLite;

namespace NurseryServise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigureSqlLiteConnection();
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


            command.CommandText = @"CREATE TABLE animals_type( Id INT AUTO_INCREMENT PRIMARY KEY,
                    Type_name VARCHAR(20) );";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE home_animals( Id INT AUTO_INCREMENT PRIMARY KEY,
                    Kind_name VARCHAR(20),
                    Type_id INT,
                    FOREIGN KEY (Type_id) REFERENCES animals_type (Id) ON DELETE CASCADE ON UPDATE CASCADE );";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE BEAST_OF_BURDEN( Id INT AUTO_INCREMENT PRIMARY KEY,
                    Kind_name VARCHAR(20),
                    Type_id INT,
                    FOREIGN KEY (Type_id) REFERENCES animals_type (Id) ON DELETE CASCADE ON UPDATE CASCADE );";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE dog (Id INT AUTO_INCREMENT PRIMARY KEY, 
                    Name VARCHAR(20), 
                    Birthday DATE,
                    Commands VARCHAR(50),
                    Kind_id int,
                    Foreign KEY (Kind_id) REFERENCES home_animals (Id) ON DELETE CASCADE ON UPDATE CASCADE);";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE cat(Id INT AUTO_INCREMENT PRIMARY KEY, 
                    Name VARCHAR(20), 
                    Birthday DATE,
                    Commands VARCHAR(50),
                    Kind_id int,
                    Foreign KEY (Kind_id) REFERENCES home_animals (Id) ON DELETE CASCADE ON UPDATE CASCADE);";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE hamster (Id INT AUTO_INCREMENT PRIMARY KEY, 
                    Name VARCHAR(20), 
                    Birthday DATE,
                    Commands VARCHAR(50),
                    Kind_id int,
                    Foreign KEY (Kind_id) REFERENCES home_animals (Id) ON DELETE CASCADE ON UPDATE CASCADE);";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE horse (Id INT AUTO_INCREMENT PRIMARY KEY, 
                    Name VARCHAR(20), 
                    Birthday DATE,
                    Commands VARCHAR(50),
                    Kind_id int,
                    Foreign KEY (Kind_id) REFERENCES beast_of_burden (Id) ON DELETE CASCADE ON UPDATE CASCADE);";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE camel (Id INT AUTO_INCREMENT PRIMARY KEY, 
                    Name VARCHAR(20), 
                    Birthday DATE,
                    Commands VARCHAR(50),
                    Kind_id int,
                    Foreign KEY (Kind_id) REFERENCES beast_of_burden (Id) ON DELETE CASCADE ON UPDATE CASCADE);";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE donkey (Id INT AUTO_INCREMENT PRIMARY KEY, 
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