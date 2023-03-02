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
    }
}
