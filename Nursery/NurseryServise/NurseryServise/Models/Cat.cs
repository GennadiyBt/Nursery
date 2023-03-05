namespace NurseryServise.Models
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
