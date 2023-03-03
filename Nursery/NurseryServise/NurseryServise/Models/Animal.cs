using NurseryServise.Models.Skills;

namespace NurseryServise.Models
{
    public abstract class Animal
    {
        protected string type;
        protected int id_type;
        public string kind;
        protected int id_kind;
        protected string name;
        protected int id;
        protected DateTime birthday;
        protected List<ISkill> skills;

        public string getType()
        {
            return type;
        }
        public int getTypId()
        {
            return id_type;
        }
        public string getKind()
        {
            return kind;
        }
        public int getKindId()
        {
            return id_kind;
        }
        public string getName()
        {
            return name;
        }
        public void setName(string value)
        {
            name = value;
        }
        public int getId()
        {
            return id;
        }
        public void setId(int value)
        {
            id = value;
        }
        public DateTime getBirthDay()
        {
            return birthday;
        }
        public void setBirthday(DateTime value)
        {
            birthday = value;
        }
        public void addSkill(ISkill skill) 
        {
            skills.Add(skill);
        }

        public List<ISkill> getSkills()
        {
            return skills;
        }

        public override string ToString()
        {
            return name + ", " + birthday;
        }
    }
}
