using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryConsole.Models.Desingers
{
    // Класс конструктора
    public abstract class Constructor
    {
        public static Animal createNewAnimal(string kind, string name, DateTime date)
        {
            switch (kind)
            {
                case "Dog": return new Dog(name, date);
                case "Cat": return new Cat(name, date);
                case "Hamster": return new Hamster(name, date);
                case "Hors": return new Hors(name, date);
                case "Camel": return new Camel(name, date);
                case "Donkey": return new Donkey(name, date);
            }
            return null;
        }
    }
}
