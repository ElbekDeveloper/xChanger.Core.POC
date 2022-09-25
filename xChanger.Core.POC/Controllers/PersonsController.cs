using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using xChanger.Core.POC.Models.Orchestrations.PersonPets;
using xChanger.Core.POC.Services.Orchestrations.PersonPets;

namespace xChanger.Core.POC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController
    {
        private readonly IPersonPetOrchestrationService personPetOrchestrationService;

        public PersonsController(IPersonPetOrchestrationService personPetOrchestrationService) =>
            this.personPetOrchestrationService = personPetOrchestrationService;

        [HttpPost]
        public async ValueTask<ActionResult<PersonPet>> PostPersonWithPetsAsync(PersonPet personPet) =>
           await this.personPetOrchestrationService.ProcessPersonWithPetsAsync(personPet);
    }
}
