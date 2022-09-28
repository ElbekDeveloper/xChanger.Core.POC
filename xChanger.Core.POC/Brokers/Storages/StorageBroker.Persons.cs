using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using xChanger.Core.POC.Models.Foundations.Persons;
using xChanger.Core.POC.Models.Foundations.Pets;

namespace xChanger.Core.POC.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Person> Persons { get; set; }

        public async ValueTask<Person> AddPersonAsync(Person person)
        {
            var broker = new StorageBroker(this.configuration);

            EntityEntry<Person> personEntityEntry =
                await broker.Persons.AddAsync(person);

            await broker.SaveChangesAsync();

            return personEntityEntry.Entity;
        }

        public IQueryable<Person> SelectAllPersons()
        {
            var broker = new StorageBroker(this.configuration);

            return broker.Persons;
        }

        public IQueryable<Person> SelectAllPersonsWithPets()
        {
            var broker = new StorageBroker(this.configuration);

            return broker.Persons.Include(person => person.Pets);
        }


        public async ValueTask<Person> UpdatePersonAsync(Person person)
        {
            var broker = new StorageBroker(this.configuration);

            EntityEntry<Person> personEntityEntry =
                broker.Persons.Update(person);

            await broker.SaveChangesAsync();

            return personEntityEntry.Entity;
        }
    }
}
