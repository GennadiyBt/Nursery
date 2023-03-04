using NurseryServise.Models;
using NurseryServise.Models.Skills;
using System.Security.Cryptography;

namespace NurseryServise.Services
{
    public interface IAnimalRepository 
    {
        int Create(Animal entity);
        int Train(Animal animal, ISkill skill);
        string GetSkills(Animal animal);
        List<Animal> GetAll(string kynd);
        Animal GetById(string kind, int id);
        int Delete(Animal animal);
    }
}
