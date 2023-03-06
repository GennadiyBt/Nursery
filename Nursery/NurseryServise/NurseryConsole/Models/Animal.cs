using NurseryConsole.Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryConsole.Models
{
    public abstract class Animal
    {
        protected string? type;
        protected int id_type;
        public string? kind;
        protected int id_kind;
        protected string? name;
        protected int id;
        protected DateTime birthday;
        protected List<ISkill> skills = new List<ISkill>();

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
            return "Id: " + id + " Имя: " + name + " Дата рождения: " + birthday.ToShortDateString();
        }

        public void registerSkils()
        {
            Console.WriteLine("Перечень умений: ");
            foreach (ISkill skill in skills)
            {
                Console.Write(skill.ToString()+"\n");
            }
            Console.WriteLine();
        }
    }
}
