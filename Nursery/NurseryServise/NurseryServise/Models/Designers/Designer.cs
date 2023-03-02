using System.Runtime.CompilerServices;

namespace NurseryServise.Models.Designers
{
    // Класс конструктора
    public abstract class Constructor
    {
        public Animal createNewAnimal(int type, int kind, string name, DateTime date) {

            Animal newAnimal = createAnimal (type, kind);
            newAnimal.setName (name);
            newAnimal.setBirthday (date);
            return newAnimal;
    
        }

        private Animal createAnimal(int type, int kind)
        {
            if (type == 1)
            {
                switch (kind)
                {
                    case 1:
                        return new Dog();
                    case 2:
                        return new Cat();
                    case 3:
                        return new Hamster();
                }
            }
            else if (type == 2)
            {
                switch (kind)
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
