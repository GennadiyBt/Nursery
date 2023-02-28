using Microsoft.Azure.Management.Storage.Fluent.Models;

namespace NurseryServise.Models
{
    public class Dog : HomeAnimal
    {
        public Dog()
        {
            kind = "Dog";
            id_kind = 1;
        }
    }
}
