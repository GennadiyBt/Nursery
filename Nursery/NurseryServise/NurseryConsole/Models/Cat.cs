using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryConsole.Models
{
    public class Cat : HomeAnimal
    {
        public Cat(string name, DateTime birthday)
        {
            kind = "Cat";
            id_kind = 2;
            this.name = name;
            this.birthday = birthday;
        }
    }
}
