using System.Threading.Tasks;
using xChanger.Core.POC.Models.Orchestrations.PersonPets;

namespace xChanger.Core.POC.Services.Orchestrations.PersonPets
{
    public interface IPersonPetOrchestrationService
    {
        ValueTask<PersonPet> ProcessPersonWithPetsAsync(PersonPet personPet);
    }
}
