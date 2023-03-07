using NurseryConsole.Models;
using NurseryConsole.Models.Skills;

namespace NurseryConsole.Services
{
    public interface IAnimalRepository
    {
        int Create(Animal entity);
        int Train(Animal trainingAnimal, ISkill _skill, string listSkills);
        List<Animal> GetAllofKind(string kynd);
        Animal GetById(string kind, int id);
        int Delete(Animal animal);
        void GetAll();
    }
}
