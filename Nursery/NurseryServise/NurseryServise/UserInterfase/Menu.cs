namespace NurseryServise.UserInterfase
{
    public class Menu
    {
        public void start()
        {
            Console.WriteLine("\n1 - Список всех животных\n2 - Завести новое животное\n3 - Изменить данные о животном\n" +
                "4 - Что умеет животное\n5 - Дрессировка\n6 - Удалить запись\n0 - Выход");
            int input = Convert.ToInt32(Console.ReadLine());

            switch (input) 
            {
                case 1:
                    break;
                case 2:
                    
                case 3: 
                    break;
                case 4: 
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 0:
                    break;
            }
        }

        public void addAnimal() 
        {
            
        }
    }
}
