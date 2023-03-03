namespace NurseryServise.Models.Skills
{
    public class Skill : ISkill
    {
        internal string skill_name { get; set; }

        public override string ToString() { return skill_name; }
   
    }
}
