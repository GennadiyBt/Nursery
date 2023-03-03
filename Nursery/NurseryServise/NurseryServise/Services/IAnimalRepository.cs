using NurseryServise.Models;

namespace NurseryServise.Services
{
    public interface IAnimalRepository : IRepository<Animal, int>
    {
        int Train(int item);
        string GetSkills(Animal animal);
    }
}
