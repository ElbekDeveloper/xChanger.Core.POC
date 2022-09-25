using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using xChanger.Core.POC.Models.Foundations.Pets;
using xChanger.Core.POC.Services.Foundations.Pets;

namespace xChanger.Core.POC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : RESTFulController
    {
        private readonly IPetService petService;

        public PetsController(IPetService petService) =>
            this.petService = petService;

        [HttpPost]
        public async ValueTask<ActionResult<Pet>> PostPetAsync(Pet pet) =>
            await this.petService.AddPetAsync(pet);
    }
}
