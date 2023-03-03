using Microsoft.AspNetCore.Mvc;
using NurseryServise.Models;
using NurseryServise.Models.Skills;
using NurseryServise.Services;

namespace NurseryServise.Controllers
{
    public class SkillController
    {
        ISkillRepository _skillRepository;

        public SkillController(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public ActionResult<int> CreateSkill(ISkill _skill)
        {
            return _skillRepository.CreateSkill(_skill);
        }

        public ActionResult<int> Delete(string name)
        {
            return _skillRepository.Delete(name);
        }

        public ActionResult<List<Skill>> GetAll()
        {
            return _skillRepository.GetAll();
        }

        public ActionResult<Skill> GetByName(string name)
        {
            return _skillRepository.GetByName(name);
        }
    }
}
