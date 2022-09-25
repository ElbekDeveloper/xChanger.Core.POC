using System.Linq;
using System.Threading.Tasks;
using xChanger.Core.POC.Brokers.Storages;
using xChanger.Core.POC.Models.Foundations.Pets;

namespace xChanger.Core.POC.Services.Foundations.Pets
{
    public class PetService : IPetService
    {
        private readonly IStorageBroker storageBroker;

        public PetService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public async ValueTask<Pet> AddPetAsync(Pet pet) =>
            await storageBroker.AddPetAsync(pet);

        public IQueryable<Pet> RetrieveAllPets() =>
            this.storageBroker.SelectAllPets();

        public async ValueTask<Pet> UpdatePetAsync(Pet pet) =>
            await storageBroker.UpdatePetAsync(pet);
    }
}
