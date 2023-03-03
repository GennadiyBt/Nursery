using Microsoft.OpenApi.Expressions;

namespace NurseryServise.UserInterfase
{
    public class InputData
    {
        internal string animalName; 
        internal DateTime birsday;
        internal int id_type;
        internal int id_kind;

        public void input()
        {
            while (true)
            {
                Console.WriteLine("Введите тип животного:\n1 - домашнее животное\n2 - вьючное животное");
                id_type = Convert.ToInt32(Console.ReadLine());
                if (id_type == 1)
                {
                    Console.WriteLine("Введите вид животного:\n1 - собака\n2 - кошка\n3 - хомяк");
                    id_kind = Convert.ToInt32(Console.ReadLine());
                    if(id_kind == 1 || id_kind == 2 || id_kind == 3) { break; }
                }
                else if (id_type == 2)
                {
                    Console.WriteLine("Введите вид животного:\n1 - лошадь\n2 - верблюд\n3 - осел");
                    id_kind = Convert.ToInt32(Console.ReadLine());
                    if (id_kind == 1 || id_kind == 2 || id_kind == 3) { break; }
                }
                else {Console.WriteLine("Введите корректное значение");}
            }
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
