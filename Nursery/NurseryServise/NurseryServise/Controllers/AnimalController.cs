﻿using Microsoft.AspNetCore.Mvc;
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
        public int Train(Animal animal, ISkill _skill)
        {
            return _animalRepository.Train(animal, _skill);
        }

        public Animal GetById(string kind, int id)
        {
            return _animalRepository.GetById(kind, id);
        }

        public int Create()
        {   
            View _view = new View();
            _view.inputAnimal();
            Animal animal = Constructor.createNewAnimal(_view.kind, _view.animalName, _view.birsday);
            return _animalRepository.Create(animal);
        }

         public int Delete(Animal animal)
        {
            return _animalRepository.Delete(animal);
        }

        public List<Animal> GetAll(string kind)
        {
            return _animalRepository.GetAll(kind);
        }

        public string GetSkills(Animal item) 
        {
            return _animalRepository.GetSkills(item);
        }
        
    }
}
