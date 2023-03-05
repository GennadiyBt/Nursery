namespace NurseryServise.Models
{
    public class Camel : BeastOfBurden
    {
        public Camel(string name, DateTime birthday)
        {
            kind = "Camel";
            id_kind = 2;
            this.name = name;
            this.birthday = birthday;
        }
    }
}
