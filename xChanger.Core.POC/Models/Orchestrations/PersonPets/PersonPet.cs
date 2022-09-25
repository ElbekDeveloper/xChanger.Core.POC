using System.Collections.Generic;
using xChanger.Core.POC.Models.Foundations.Persons;
using xChanger.Core.POC.Models.Foundations.Pets;

namespace xChanger.Core.POC.Models.Orchestrations.PersonPets
{
    public class PersonPet
    {
        public Person Person { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
