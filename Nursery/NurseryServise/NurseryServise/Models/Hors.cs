namespace NurseryServise.Models
{
    public class Hors : BeastOfBurden
    {
        public Hors(string name, DateTime birthday)
        {
            kind = "Hors";
            id_kind = 1;
            this.name = name;
            this.birthday = birthday;
        }
    }
}
