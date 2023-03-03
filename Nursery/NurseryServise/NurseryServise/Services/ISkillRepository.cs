using NurseryServise.Models.Skills;
using System.Security.Cryptography;

namespace NurseryServise.Services
{
    public interface ISkillRepository 
    {
        List<Skill> GetAll();
        Skill GetByName(string name);
        int Create(string name);

        int Delete(string name);
    }

    
}
