using Microsoft.OpenApi.Expressions;

namespace NurseryServise.UserInterfase
{
    public class InputData
    {
        internal string animalName; 
        internal DateTime birsday;
        internal int id_type;
        internal int id_kind;
        internal string kind;

        public void input()
        {
            string key = Menu.listAnimal();
            kind = key;

            while (true)
            {
                Console.WriteLine("Введите имя животного:");
                try 
                { 
                    animalName = Console.ReadLine();
                    break;
                }
                catch (InvalidCastException e)
                { Console.WriteLine("Введите корректные данные"); }
            }


            while (true)
            {
                try
                {
                    Console.WriteLine("Введите дату рождения животного:\n число:");
                    int day = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("месяц:");
                    int month = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("год:");
                    int year = Convert.ToInt32(Console.ReadLine());
                    birsday = new DateTime(year, month, day);
                }
                catch (InvalidCastException e)
                { Console.WriteLine("Введите корректные данные"); }
            }

        }
    }
}
