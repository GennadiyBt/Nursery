namespace NurseryServise.Models
{
    public abstract class BeastOfBurden : Animal;
    {
        protected BeastOfBurden() {
            type = "Beast of burden";
            id_type = 2;
        }
    }
}
