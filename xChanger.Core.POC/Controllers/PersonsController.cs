using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using xChanger.Core.POC.Models.Orchestrations.PersonPets;
using xChanger.Core.POC.Services.Coordinations;
using xChanger.Core.POC.Services.Foundations.Persons;

namespace xChanger.Core.POC.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PersonsController : RESTFulController
    {
        private readonly IExternalPersonWithPetsCoordinationService externalPersonWithPetsCoordinationService;
        private readonly IPersonService personService;

        public PersonsController(
            IExternalPersonWithPetsCoordinationService externalPersonWithPetsCoordinationService,
            IPersonService personService)
        {
            this.externalPersonWithPetsCoordinationService = externalPersonWithPetsCoordinationService;
            this.personService = personService;
        }

        [HttpGet]
        public async ValueTask<ActionResult<List<PersonPet>>> GetStoredPersons() =>
            Ok(await this.externalPersonWithPetsCoordinationService.CoordinateExternalPersons());


        [HttpGet]
        public ActionResult<IQueryable<PersonPet>> GetAllPersonsWithPets() =>
            Ok(this.personService.RetrieveAllPersonsWithPets());
    }
}
