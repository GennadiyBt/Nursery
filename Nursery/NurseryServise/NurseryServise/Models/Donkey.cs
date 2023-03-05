namespace NurseryServise.Models
{
    public class Donkey : BeastOfBurden 
    {
        public Donkey(string name, DateTime birthday)
        {
            kind = "Donkey";
            id_kind = 3;
            this.name = name;
            this.birthday = birthday;
        }
    }
}
