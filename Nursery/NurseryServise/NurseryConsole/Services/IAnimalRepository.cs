using NurseryConsole.Models;
using NurseryConsole.Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryConsole.Services
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
