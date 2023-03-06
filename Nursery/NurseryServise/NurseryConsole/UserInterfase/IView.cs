using NurseryConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryConsole.UserInterfase
{
    public interface IView
    {
        void listOfAnimals(List<Animal> animals);
        void inputAnimal();
        string inputKind();
        Animal choice();
    }
}
