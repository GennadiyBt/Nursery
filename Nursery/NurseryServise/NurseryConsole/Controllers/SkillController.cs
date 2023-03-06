using NurseryConsole.Models.Skills;
using NurseryConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryConsole.Controllers
{
    public class SkillController
    {
        ISkillRepository _skillRepository;

        public SkillController(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public int CreateSkill(ISkill _skill)
        {
            return _skillRepository.CreateSkill(_skill);
        }

        public int Delete(string name)
        {
            return _skillRepository.Delete(name);
        }

        public List<Skill> GetAll()
        {
            return _skillRepository.GetAll();
        }

        public Skill GetByName(string name)
        {
            return _skillRepository.GetByName(name);
        }
    }
}
