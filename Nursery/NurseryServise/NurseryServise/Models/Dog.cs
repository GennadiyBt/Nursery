using Microsoft.Azure.Management.Storage.Fluent.Models;

namespace NurseryServise.Models
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
