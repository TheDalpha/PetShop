using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oliver.PetShop.Core.DomainService;
using Oliver.PetShop.Core.Entity;

namespace Oliver.PetShop.Core.ApplicationService.impl
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepo;

        public PetService(IPetRepository petRepository)
        {
            _petRepo = petRepository;
        }

        public List<Pet> GetPets()
        {
            var listPets = _petRepo.ReadPets().ToList();
            return listPets;
        }

        public void DeletePet(int id)
        {
            _petRepo.DeletePet(id);
        }

        public Pet AddPet(Pet pet)
        {
            return _petRepo.CreatePet(pet);
        }

        public Pet GetInstance()
        {
            return new Pet();
        }

        public Pet ReadById(int id)
        {
            return _petRepo.ReadById(id);
        }

        public List<Pet> Get5CheapestPets()
        {
            return _petRepo.ReadPets().OrderBy(pet => pet.Price).Take(5).ToList();
        }

        public List<Pet> Search(string type)
        {

            return _petRepo.ReadPets().OrderBy(pet => pet.Type.Contains(type) || type == null).ToList();
        }

        public List<Pet> SortByPrice()
        {
            return _petRepo.ReadPets().OrderBy(pet => pet.Price).ToList();
        }
    }
}
