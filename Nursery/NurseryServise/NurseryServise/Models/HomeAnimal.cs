namespace NurseryServise.Models
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
