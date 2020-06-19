using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_Test.Models;

namespace WebAPI_Test.Services
{
    public interface IAPBDDbService
    {
        Task<ICollection<Pet>> GetPets(string year);
        Task AddPet(POJO pOJO);
    }
}
