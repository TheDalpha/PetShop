using Oliver.PetShop.Core.DomainService;
using Oliver.PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oliver.PetShop.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.Pets;
        }
        
        public void DeletePet(int id)
        {
            var pets = FakeDB.Pets.ToList();
            var deletePet = pets.FirstOrDefault(pet => pet.Id == id);
            pets.Remove(deletePet);
            FakeDB.Pets = pets;

        }

        public Pet CreatePet(Pet pet)
        {
            pet.Id = FakeDB.PetId++;
            var pets = FakeDB.Pets.ToList();
            pets.Add(pet);
            FakeDB.Pets = pets;
            return pet;
        }

        public Pet ReadById(int id)
        {
            var pets = FakeDB.Pets.ToList();

            foreach (var pet in pets)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }
            return null;
        }

        //public List<Pet> Search(string type)
        //{
        //    var pets = FakeDB.Pets.ToList();

        //    foreach (var pet in pets)
        //    {
        //        if (pet.Type == type)
        //        {
        //            return ReadPets().OrderBy(pet => pet.Type).ToList();
        //        }
        //    }
        //    return null;
        //}
    }
}
