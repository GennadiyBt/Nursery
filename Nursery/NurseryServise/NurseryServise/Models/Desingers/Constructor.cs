using System.Runtime.CompilerServices;

namespace NurseryServise.Models.Designers
{
    // Класс конструктора
    public abstract class Constructor
    {
        public static Animal createNewAnimal(int id_type, int id_kind, string name, DateTime date) {

            Animal newAnimal = createAnimal (id_type, id_kind);
            newAnimal.setName (name);
            newAnimal.setBirthday (date);
            return newAnimal;
    
        }

        public static Animal createNewAnimal(string kind, string name, DateTime date)
        {
            switch (kind)
            {
                case "Dog": return new Dog();
                case "Cat": return new Cat();
                case "Hamster": return new Hamster();
                case "Hors": return new Hors();
                case "Camel": return new Camel();
                case "Donkey": return new Donkey();
            }
            return null;
        }

        private static Animal createAnimal(int id_type, int id_kind)
        {
            if (id_type == 1)
            {
                switch (id_kind)
                {
                    case 1:
                        return new Dog();
                    case 2:
                        return new Cat();
                    case 3:
                        return new Hamster();
                }
            }
            else if (id_type == 2)
            {
                switch (id_kind)
                {
                    case 1:
                        return new Hors();
                    case 2:
                        return new Camel();
                    case 3:
                        return new Donkey();
                }
            }
            return null;
        }
    }
}
