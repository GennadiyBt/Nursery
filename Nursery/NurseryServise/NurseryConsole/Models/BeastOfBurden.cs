using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryConsole.Models
{
    public abstract class BeastOfBurden : Animal
    {
        protected BeastOfBurden()
        {
            type = "Beast of burden";
            id_type = 2;
        }
    }
}
