namespace NurseryServise.Models.Skills
{
    public class Skill : ISkill
    {
        internal string skill_name { get; set; }

        public Skill(string skill_name)
        {
            this.skill_name = skill_name;
        }

        public override string ToString() { return skill_name; }
   
    }
}
