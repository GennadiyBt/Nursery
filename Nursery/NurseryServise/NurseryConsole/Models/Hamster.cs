using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryConsole.Models
{
    public class Hamster : HomeAnimal
    {
        public Hamster(string name, DateTime birthday)
        {
            kind = "Hamcter";
            id_kind = 3;
            this.name = name;
            this.birthday = birthday;
        }
    }
}
