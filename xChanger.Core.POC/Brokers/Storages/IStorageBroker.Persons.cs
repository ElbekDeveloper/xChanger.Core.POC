using System.Linq;
using System.Threading.Tasks;
using xChanger.Core.POC.Models.Foundations.Persons;

namespace xChanger.Core.POC.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Person> AddPersonAsync(Person person);
        IQueryable<Person> SelectAllPersons();
        IQueryable<Person> SelectAllPersonsWithPets();
        ValueTask<Person> UpdatePersonAsync(Person person);
    }
}
