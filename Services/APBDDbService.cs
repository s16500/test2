using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Test.Exceptions;
using WebAPI_Test.Models;

namespace WebAPI_Test.Services
{
    public class APBDDbService : IAPBDDbService
    {

        private readonly APBDContext _context;

        public APBDDbService(APBDContext context)
        {
            _context = context;
        }

        public async Task AddPet(POJO pOJO)
        {
            try
            {
                var breed = await _context.BreedTypes.FirstOrDefaultAsync(x => x.Name.ToLower() == pOJO.BreedName.ToLower());
                if (breed != null)
                {
                    await InsertPet(pOJO, breed.IdBreedType);
                }
                else
                {
                    breed = await InsertBreed(pOJO);
                    if (breed != null)
                    {
                        await InsertPet(pOJO, breed.IdBreedType);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new RecordCanNotBeInserted("There is some issues while inserting the database");
            }
        }

        private async Task<BreedType> InsertBreed(POJO pOJO)
        {
            var breed = await _context.BreedTypes.AddAsync(new BreedType { Name = pOJO.Name, Description = "" });
            await _context.SaveChangesAsync();
            return breed.Entity;
        }

        private async Task<Pet> InsertPet(POJO pOJO, int breedType)
        {
            var pet = await _context.Pets.AddAsync(new Pet
            {
                Name = pOJO.Name,
                IdBreedType = breedType,
                ApprocimateDateOfBirth = pOJO.ApprocimatedDateOfBirth,
                DateRegistered = pOJO.DateRegistered,
                IsMale = pOJO.IsMale
            });

            var volunterrPet = await _context.VolunteerPets.AddAsync(new VolunteerPet { IdPet = pet.Entity.IdPet, DateAccepted = DateTime.Now, IdVolunteer = 1 });

            await _context.SaveChangesAsync();

            return pet.Entity;
        }


        public async Task<ICollection<Pet>> GetPets(string year)
        {
            var pets = await _context.Pets.Include(x => x.BreedType).Where(x => x.DateRegistered.Year == Convert.ToInt32(year) || string.IsNullOrEmpty(year)).ToListAsync();
            if (pets != null && pets.Count > 0)
            {
                return pets;
            }
            else
            {
                throw new NoRecordsExistException("Database does not have any records.");
            }
        }

    }
}
