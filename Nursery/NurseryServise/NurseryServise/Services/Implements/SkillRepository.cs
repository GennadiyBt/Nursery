using NurseryServise.Models.Skills;

namespace NurseryServise.Services.Implements
{
    public class SkillRepository : ISkillRepository
    {
        private const string connectionString = "Data Source = nursery.db; Version = 3; Pooling = true; Max Pool Size = 100;";

        public int Create(ISkill item)
        {
            throw new NotImplementedException();
        }


        public int Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<ISkill> GetAll()
        {
            throw new NotImplementedException();
        }


        public ISkill GetById(string id)
        {
            throw new NotImplementedException();
        }

    }
}
