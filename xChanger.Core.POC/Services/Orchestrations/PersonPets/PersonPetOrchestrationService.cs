using System.Collections.Generic;
using System.Threading.Tasks;
using xChanger.Core.POC.Models.Foundations.Persons;
using xChanger.Core.POC.Models.Foundations.Pets;
using xChanger.Core.POC.Models.Orchestrations.PersonPets;
using xChanger.Core.POC.Services.Processings.Persons;
using xChanger.Core.POC.Services.Processings.Pets;

namespace xChanger.Core.POC.Services.Orchestrations.PersonPets
{
    public class PersonPetOrchestrationService : IPersonPetOrchestrationService
    {
        private readonly IPersonProcessingService personProcessingService;
        private readonly IPetProcessingService petProcessingService;

        public PersonPetOrchestrationService(
            IPersonProcessingService personProcessingService,
            IPetProcessingService petProcessingService)
        {
            this.personProcessingService = personProcessingService;
            this.petProcessingService = petProcessingService;
        }

        public async ValueTask<PersonPet> ProcessPersonWithPetsAsync(PersonPet personPet)
        {
            Person processedPerson =
                await this.personProcessingService.UpsertPersonAsync(personPet.Person);

            PersonPet processedPersonPet = MapToPersonPet(processedPerson);

            foreach (Pet pet in personPet.Pets)
            {
                Pet processedPet = await this.petProcessingService.UpsertPetAsync(pet);
                processedPersonPet.Pets.Add(processedPet);
            }

            return processedPersonPet;
        }

        private static PersonPet MapToPersonPet(Person processedPerson)
        {
            return new PersonPet
            {
                Person = processedPerson,
                Pets = new List<Pet>()
            };
        }
    }
}
