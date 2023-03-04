using NurseryServise.Controllers;
using NurseryServise.Models;
using NurseryServise.Models.Skills;
using NurseryServise.Services;

namespace NurseryServise.UserInterfase
{
    public abstract class Menu
    {
        AnimalController animalController { get; set; }

        public Menu(AnimalController animalController)
        {
            this.animalController = animalController;
        }
        public void start()
        {
            IView _view = new View(animalController);
            Boolean flag = true;
            while (flag)
            {
                Console.WriteLine("\n1 - Список всех животных нужного вида\n2 - Завести новое животное\n" +
                "3 - Что умеет животное\n4 - Дрессировка\n5 - Удалить запись\n0 - Выход");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Просмотр животных по видам.");
                        string key = _view.inputKind();
                        if (key == "Back") { break; }
                        List<Animal> animals = animalController.GetAll(key);
                        _view.listOfAnimals(animals);
                        break;
                    case 2:
                        // В языке C#  try-with-resources конструкция не предусмотрена, используем using
                        using (Counter counter = new Counter())
                        {
                            animalController.Create();
                            break;
                        }
                        
                    case 3:
                        Console.WriteLine(animalController.GetSkills(_view.choice()));
                        break;
                    case 4:
                        Console.WriteLine("Введите название команды, которой хотите научить животное:");
                        string skill;
                        while (true)
                        {
                            skill = Console.ReadLine();
                            if (skill != null) { break; }
                            else { Console.WriteLine("Вы ввели пустую строку. Попробуйте еще раз."); }
                           
                        }
                        ISkill newSkill = new Skill(skill);
                        animalController.Train(_view.choice(), newSkill);
                        break;
                    case 5:
                        animalController.Delete(_view.choice());
                        break;
                    case 0:
                        flag = false;
                        break;
                }
            }
        }
        
    }
}
