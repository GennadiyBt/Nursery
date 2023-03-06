using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryConsole.Models
{
    public abstract class HomeAnimal : Animal
    {
        public HomeAnimal()
        {
            type = "Home animal";
            id_type = 1;
        }
    }
}
