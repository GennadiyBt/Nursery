using NurseryServise.Models.Skills;
using System.Security.Cryptography;

namespace NurseryServise.Services
{
    public interface ISkillRepository 
    {
        List<Skill> GetAll();
        Skill GetByName(string name);
        int CreateSkill(ISkill skill);

        int Delete(string name);
    }

    
}
