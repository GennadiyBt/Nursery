using NurseryServise.Services;

namespace NurseryServise.Controllers
{
    public class AnimalController
    {
        private IAnimalRepository _animalRepository;
        public AnimalController(IAnimalRepository animalRepository) {
            _animalRepository = animalRepository;
        }
    }
}
