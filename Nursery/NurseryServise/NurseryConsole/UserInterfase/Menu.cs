using NurseryConsole.Controllers;
using NurseryConsole.Models;
using NurseryConsole.Models.Skills;
using NurseryConsole.Services;

namespace NurseryConsole.UserInterfase
{
    public class Menu
    {
        AnimalController animalController { get; set; }

        public Menu(AnimalController animalController)
        {
            this.animalController = animalController;
        }
        public void start()
        {
            Boolean flag = true;
            while (flag)
            {
                View _view = new View(animalController);
                Console.WriteLine("\n1 - Список всех животных нужного вида\n2 - Завести новое животное\n" +
                "3 - Найти животное \n0 - Выход");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Просмотр животных по видам.");
                        string key = _view.inputKind();
                        if (key.Equals("Back")) { break; }

                        List<Animal> animals = animalController.GetAll(key);
                        _view.listOfAnimals(animals);
                        break;
                    case 2:
                        // В языке C#  try-with-resources конструкция не предусмотрена, используем using
                        using (Counter counter = new Counter())
                        {
                            animalController.Create(_view);
                            break;
                        }
                    case 3:
                        {
                            subMenu(_view);
                            break;
                        }
                    case 0:
                        flag = false;
                        break;
                }
            }
        }

        public int subMenu(View _view) //Метод с возвращаемым значением для возможности его остановки в нужный момент через return
        {
            Boolean flag = true;
            Animal _animal = _view.choice();
            string skills = "";
            if (_animal.getSkills().Count > 0)
            {
                foreach (ISkill item in _animal.getSkills())
                {
                    skills += " ";
                    skills += item.ToString();
                }
            }
            try
            {
                Console.WriteLine("Найдено следующее животное: \n" + _animal.ToString());
            }
            catch (Exception ex) { Console.WriteLine("Нет такого животного\n"); return -1; }
            while (flag)
            {
                Console.WriteLine("Вы можете просмотреть умения животного, научить новым или удалить животное из базы");
                Console.WriteLine("\n1 - Посмотреть, что умеет животное\n2 - Научить животное новой команде\n3 - Удалить запись\n0 - Вернуться в предыдущее меню");
                switch (Convert.ToUInt32(Console.ReadLine()))
                {
                    case 1:
                        _animal.registerSkils();
                        break;
                    case 2:
                        Console.WriteLine("Введите название команды, которой хотите научить животное:");
                        string skill;
                        while (true)
                        {
                            try
                            {
                                skill = Console.ReadLine();
                                break;
                            }
                            catch (NullReferenceException)
                            { Console.WriteLine("Вы ничего не указали. Попробуйте еще раз."); }
                        }
                        ISkill newSkill = new Skill(skill);
                        animalController.Train(_animal, newSkill, skills);
                        break;
                    case 3:
                        animalController.Delete(_animal);
                        break;
                    case 0:
                        flag = false;
                        break;
                }
            }
            return 0;
        }


    }
}
