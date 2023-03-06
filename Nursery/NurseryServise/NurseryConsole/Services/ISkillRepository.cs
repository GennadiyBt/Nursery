using NurseryConsole.Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryConsole.Services
{
    public interface ISkillRepository
    {
        List<Skill> GetAll();
        Skill GetByName(string name);
        int CreateSkill(ISkill skill);

        int Delete(string name);
    }
}
