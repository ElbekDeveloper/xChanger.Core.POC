using System.Linq;
using System.Threading.Tasks;
using xChanger.Core.POC.Brokers.Storages;
using xChanger.Core.POC.Models.Foundations.Persons;

namespace xChanger.Core.POC.Services.Foundations.Persons
{
    public class PersonService : IPersonService
    {
        private readonly IStorageBroker storageBroker;

        public PersonService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public async ValueTask<Person> AddPersonAsync(Person person) =>
            await storageBroker.AddPersonAsync(person);

        public IQueryable<Person> RetrieveAllPersons() =>
            this.storageBroker.SelectAllPersons();


        public async ValueTask<Person> UpdatePersonAsync(Person person) =>
            await storageBroker.UpdatePersonAsync(person);
    }
}
