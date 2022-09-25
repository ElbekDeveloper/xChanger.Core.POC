using System.Threading.Tasks;
using xChanger.Core.POC.Models.Foundations.Persons;

namespace xChanger.Core.POC.Services.Processings.Persons
{
    public interface IPersonProcessingService
    {
        ValueTask<Person> UpsertPersonAsync(Person person);
    }
}
