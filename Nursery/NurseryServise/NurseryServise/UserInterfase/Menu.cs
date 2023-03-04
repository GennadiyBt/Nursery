using NurseryServise.Controllers;
using NurseryServise.Models;
using NurseryServise.Models.Skills;

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
            Boolean flag = true;
            while (flag)
            {
                Console.WriteLine("\n1 - Список всех животных нужного вида\n2 - Завести новое животное\n" +
                "3 - Что умеет животное\n4 - Дрессировка\n5 - Удалить запись\n0 - Выход");
                int input = Convert.ToInt32(Console.ReadLine());
                string kind;
                int id;
                Animal animal;
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Просмотр животных по видам.");
                        string key = listAnimal();
                        if (key == "Back") { break; }
                        List<Animal> animals = animalController.GetAll(key);
                        foreach (Animal item in animals)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        break;
                    case 2:
                        animalController.Create();
                        break;
                    case 3:
                        Console.WriteLine("Выберите животное по виду и  индивидуальному номеру в указанном виде.\n Введите вид:");
                        kind = listAnimal();
                        Console.WriteLine("Введите Id животного:");
                        id = Convert.ToInt32(Console.ReadLine());
                        animal = animalController.GetById(kind, id);
                        animalController.GetSkills(animal);
                        break;
                    case 4:
                        Console.WriteLine("Выберите животное по виду и  индивидуальному номеру в указанном виде.\n Введите вид:");
                        kind = listAnimal();
                        Console.WriteLine("Введите Id животного:");
                        id = Convert.ToInt32(Console.ReadLine());
                        animal = animalController.GetById(kind, id);
                        Console.WriteLine("Введите название команды, которой хотите научить животное:");
                        ISkill newSkill = new Skill(Console.ReadLine());
                        animalController.Train(animal, newSkill);
                        break;
                    case 5:
                        Console.WriteLine("Выберите животное по виду и  индивидуальному номеру в указанном виде.\n Введите вид:");
                        kind = listAnimal();
                        Console.WriteLine("Введите Id животного:");
                        id = Convert.ToInt32(Console.ReadLine());
                        animal = animalController.GetById(kind, id);
                        animalController.Delete(kind, id);
                        break;
                    case 0:
                        flag = false;
                        break;
                }
            }
        }
            internal static string listAnimal()
            {
                while (true)
                {
                    Console.WriteLine("Виды животных:\n - Dog\n - Cat\n - Hamster\n - Hors\n - Camel\n - Donkey\n" +
                    "Введите вид животного или Back для возврата в предыдущее меню");
                    string kind = Console.ReadLine();
                    if (kind == "Back") { return kind; }
                    if (kind != "Dog" && kind != "Cat" && kind != "Hamster" && kind != "Hors" && kind != "Camel" && kind != "Donkey")
                    {
                        Console.WriteLine("Такого варианта нет, попробуйте еще.");
                    }
                    else { return kind; }
                }
            }
        

        
    }
}
