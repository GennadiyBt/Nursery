namespace NurseryServise.Models
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
