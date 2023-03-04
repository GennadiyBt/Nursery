﻿using Microsoft.Azure.Management.Storage.Fluent.Models;
using NurseryServise.Controllers;
using NurseryServise.Models;

namespace NurseryServise.UserInterfase
{
    public class View : IView
    {
        internal string animalName;
        internal DateTime birsday;
        internal string kind;
        internal AnimalController animalController { get; set; }

        public View() { }
        public View(AnimalController animalController) 
        {
            this.animalController = animalController;
        }


        public Animal choice()
        {
            string kind;
            int id;
            Animal animal;

            Console.WriteLine("Выберите животное по виду и  индивидуальному номеру в указанном виде.\n Введите вид:");
            kind = inputKind();
            Console.WriteLine("Введите Id животного:");
            id = Convert.ToInt32(Console.ReadLine());
            animal = animalController.GetById(kind, id);
            return animal;
        }

        public void inputAnimal()
        {
            string key = inputKind();
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
                    break;
                }
                catch (InvalidCastException e)
                { Console.WriteLine("Введите корректные данные"); }
            }

        }

        public string inputKind()
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

        public void listOfAnimals(List<Animal> animals)
        {
            foreach (Animal item in animals)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
