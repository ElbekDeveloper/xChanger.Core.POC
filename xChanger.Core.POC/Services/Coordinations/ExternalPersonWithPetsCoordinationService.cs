using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using xChanger.Core.POC.Models.Foundations.ExternalPersons;
using xChanger.Core.POC.Models.Foundations.Persons;
using xChanger.Core.POC.Models.Foundations.Pets;
using xChanger.Core.POC.Models.Orchestrations.PersonPets;
using xChanger.Core.POC.Services.Orchestrations.PersonPets;
using xChanger.Core.POC.Services.Orchestrations.ExternalPersons;

namespace xChanger.Core.POC.Services.Coordinations
{
    public class ExternalPersonWithPetsCoordinationService : IExternalPersonWithPetsCoordinationService
    {
        private readonly IExternalPersonOrchestrationService externalPersonOrchestrationService;
        private readonly IPersonPetOrchestrationService personPetOrchestrationService;

        public ExternalPersonWithPetsCoordinationService(
            IExternalPersonOrchestrationService externalPersonOrchestrationService,
            IPersonPetOrchestrationService personPetOrchestrationService)
        {
            this.externalPersonOrchestrationService = externalPersonOrchestrationService;
            this.personPetOrchestrationService = personPetOrchestrationService;
        }

        public async ValueTask<List<PersonPet>> CoordinateExternalPersons()
        {
            var returningPersonsWithPets = new List<PersonPet>();
            List<ExternalPerson> formattedExternalPersons =
                await this.externalPersonOrchestrationService.RetrieveFormattedExternalPersonsAsync();

            List<PersonPet> personsWithPets = MapToPersonWithPets(formattedExternalPersons);

            foreach (var mappedPersonWithPets in personsWithPets)
            {
                var processedPersonWithPets = await this.personPetOrchestrationService
                    .ProcessPersonWithPetsAsync(mappedPersonWithPets);

                returningPersonsWithPets.Add(processedPersonWithPets);
            }

            return returningPersonsWithPets;
        }

        private List<PersonPet> MapToPersonWithPets(List<ExternalPerson> formattedExternalPersons)
        {
            List<PersonPet> mappedPersonsWithPet = new List<PersonPet>();
            Guid personId = Guid.NewGuid();

            foreach (ExternalPerson externalPerson in formattedExternalPersons)
            {
                var mappedPersonWithPet = new PersonPet()
                {
                    Person = new Person()
                    {
                        Id = personId,
                        Name = externalPerson.PersonName,
                        Age = externalPerson.Age
                    },
                    Pets = MapPets(externalPerson, personId)
                };

                mappedPersonsWithPet.Add(mappedPersonWithPet);
            }

            return mappedPersonsWithPet;
        }

        private List<Pet> MapPets(ExternalPerson externalPerson, Guid personId)
        {
            var mappedPets = new List<Pet>();

            if (!String.IsNullOrWhiteSpace(externalPerson.PetOne))
            {
                var firstPet = new Pet
                {
                    Id = Guid.NewGuid(),
                    Name = externalPerson.PetOne,
                    Type = MapToPetType(externalPerson.PetOneType),
                    PersonId = personId
                };

                mappedPets.Add(firstPet);
            }

            if (!String.IsNullOrWhiteSpace(externalPerson.PetTwo))
            {
                var secondPet = new Pet
                {
                    Id = Guid.NewGuid(),
                    Name = externalPerson.PetTwo,
                    Type = MapToPetType(externalPerson.PetTwoType),
                    PersonId = personId
                };

                mappedPets.Add(secondPet);
            }

            if (!String.IsNullOrWhiteSpace(externalPerson.PetThree))
            {
                var thirdPet = new Pet
                {
                    Id = Guid.NewGuid(),
                    Name = externalPerson.PetThree,
                    Type = MapToPetType(externalPerson.PetThreeType),
                    PersonId = personId
                };

                mappedPets.Add(thirdPet);
            }

            return mappedPets;
        }

        private PetType MapToPetType(string petType)
        {
            PetType mappedPetType;

            return Enum.TryParse(petType, ignoreCase: true, out mappedPetType)
            ? mappedPetType
            : PetType.Other;
        }
    }
}
