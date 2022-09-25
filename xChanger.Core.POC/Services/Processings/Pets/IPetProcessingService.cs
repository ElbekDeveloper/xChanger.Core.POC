using System.Threading.Tasks;
using xChanger.Core.POC.Models.Foundations.Pets;

namespace xChanger.Core.POC.Services.Processings.Pets
{
    public interface IPetProcessingService
    {
        ValueTask<Pet> UpsertPetAsync(Pet pet);
    }
}