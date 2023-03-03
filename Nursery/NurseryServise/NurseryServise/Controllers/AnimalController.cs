using Microsoft.AspNetCore.Mvc;
using NurseryServise.Models;
using NurseryServise.Models.Designers;
using NurseryServise.Services;
using NurseryServise.UserInterfase;

namespace NurseryServise.Controllers
{
    public class AnimalController
    {
        private IAnimalRepository _animalRepository;
        public AnimalController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        public ActionResult<int> Train(int animal_id)
        {
            return _animalRepository.Train(animal_id);
        }

        public ActionResult<Animal> GetById(int id)
        {
            return _animalRepository.GetById(id);
        }

        public ActionResult<int> Create()
        {   
            InputData _inputData = new InputData();
            _inputData.input();
            Animal animal = Constructor.createNewAnimal(_inputData.type, _inputData.kind, _inputData.animalName, _inputData.birsday);
            return _animalRepository.Create(animal);
        }

        public ActionResult<int> Delete(int id)
        {
            return _animalRepository.Delete(id);
        }

        public ActionResult<List<Animal>> GetAll()
        {
            return _animalRepository.GetAll();
        }
        
    }
}
