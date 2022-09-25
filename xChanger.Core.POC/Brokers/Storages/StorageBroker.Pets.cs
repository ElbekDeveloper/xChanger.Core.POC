using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using xChanger.Core.POC.Models.Foundations.Pets;

namespace xChanger.Core.POC.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Pet> Pets { get; set; }

        public async ValueTask<Pet> AddPetAsync(Pet pet)
        {
            var broker = new StorageBroker(this.configuration);

            EntityEntry<Pet> petEntityEntry =
                await broker.Pets.AddAsync(pet);

            await broker.SaveChangesAsync();

            return petEntityEntry.Entity;
        }

        public IQueryable<Pet> SelectAllPets()
        {
            var broker = new StorageBroker(this.configuration);

            return broker.Pets;
        }


        public async ValueTask<Pet> UpdatePetAsync(Pet pet)
        {
            var broker = new StorageBroker(this.configuration);

            EntityEntry<Pet> petEntityEntry =
                broker.Pets.Update(pet);

            await broker.SaveChangesAsync();

            return petEntityEntry.Entity;
        }
    }
}
