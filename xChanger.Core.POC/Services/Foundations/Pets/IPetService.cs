using System.Linq;
using System.Threading.Tasks;
using xChanger.Core.POC.Models.Foundations.Pets;

namespace xChanger.Core.POC.Services.Foundations.Pets
{
    public interface IPetService
    {
        ValueTask<Pet> AddPetAsync(Pet pet);
        IQueryable<Pet> RetrieveAllPets();
        ValueTask<Pet> UpdatePetAsync(Pet pet);
    }
}