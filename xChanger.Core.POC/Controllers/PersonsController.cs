using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using xChanger.Core.POC.Models.Orchestrations.PersonPets;
using xChanger.Core.POC.Services.Coordinations;

namespace xChanger.Core.POC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : RESTFulController
    {
        private readonly IExternalPersonWithPetsCoordinationService externalPersonWithPetsCoordinationService;

        public PersonsController(IExternalPersonWithPetsCoordinationService externalPersonWithPetsCoordinationService) =>
            this.externalPersonWithPetsCoordinationService = externalPersonWithPetsCoordinationService;

        [HttpGet]
        public async ValueTask<ActionResult<List<PersonPet>>> GetStoredPersons() =>
            await this.externalPersonWithPetsCoordinationService.CoordinateExternalPersons();
    }
}
