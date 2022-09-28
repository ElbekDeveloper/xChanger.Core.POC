using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using xChanger.Core.POC.Models.Foundations.ExternalPersons;
using xChanger.Core.POC.Models.Orchestrations.PersonPets;
using xChanger.Core.POC.Services.Orchestrations.PersonPets;
using xChanger.Core.POC.Services.Processings.ExternalPersons;

namespace xChanger.Core.POC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : RESTFulController
    {
        private readonly IPersonPetOrchestrationService personPetOrchestrationService;
        private readonly IExternalPersonProcessingService externalPersonProcessingService;

        public PersonsController(
            IPersonPetOrchestrationService personPetOrchestrationService,
            IExternalPersonProcessingService externalPersonProcessingService)
        {
            this.personPetOrchestrationService = personPetOrchestrationService;
            this.externalPersonProcessingService = externalPersonProcessingService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<PersonPet>> PostPersonWithPetsAsync(PersonPet personPet) =>
           await this.personPetOrchestrationService.ProcessPersonWithPetsAsync(personPet);

        [HttpGet]
        public async ValueTask<ActionResult<List<ExternalPerson>>> GetFormattedExternalPersons() =>
            await this.externalPersonProcessingService.RetrieveFormattedExternalPersonsAsync();
    }
}
