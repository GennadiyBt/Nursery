using NurseryServise.Models;

namespace NurseryServise.UserInterfase
{
    public interface IView
    {
        void listOfAnimals(List<Animal> animals);
        void inputAnimal();
        string inputKind();
        Animal choice();
    }
}
