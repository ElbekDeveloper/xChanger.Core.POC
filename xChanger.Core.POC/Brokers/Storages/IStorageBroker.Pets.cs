using System.Linq;
using System.Threading.Tasks;
using xChanger.Core.POC.Models.Foundations.Pets;

namespace xChanger.Core.POC.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Pet> AddPetAsync(Pet pet);
        IQueryable<Pet> SelectAllPets();
        ValueTask<Pet> UpdatePetAsync(Pet pet);
    }
}
