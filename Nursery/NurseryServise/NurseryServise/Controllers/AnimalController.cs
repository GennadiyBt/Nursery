using Microsoft.AspNetCore.Mvc;
using NurseryServise.Models;
using NurseryServise.Models.Designers;
using NurseryServise.Models.Skills;
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
        public ActionResult<int> Train(string kind, int id, ISkill _skill)
        {
            return _animalRepository.Train(kind, id, _skill);
        }

        public ActionResult<Animal> GetById(string kind, int id)
        {
            return _animalRepository.GetById(kind, id);
        }

        public ActionResult<int> Create()
        {   
            InputData _inputData = new InputData();
            _inputData.input();
            Animal animal = Constructor.createNewAnimal(_inputData.id_type, _inputData.id_kind, _inputData.animalName, _inputData.birsday);
            return _animalRepository.Create(animal);
        }

        public ActionResult<int> Delete(string kind, int id)
        {
            return _animalRepository.Delete(kind, id);
        }

        public ActionResult<List<Animal>> GetAll(string kind)
        {
            return _animalRepository.GetAll(kind);
        }

        public ActionResult<string> GetSkills(Animal item) 
        {
            return _animalRepository.GetSkills(item);
        }
        
    }
}
