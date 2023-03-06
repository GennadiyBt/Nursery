using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryConsole.Models
{
    public class Dog : HomeAnimal
    {
        public Dog(string name, DateTime birthday)
        {
            kind = "Dog";
            id_kind = 1;
            this.name = name;
            this.birthday = birthday;
        }
    }
}
