using System.Collections.Generic;
using System.Threading.Tasks;
using xChanger.Core.POC.Models.Foundations.ExternalPersons;

namespace xChanger.Core.POC.Services.Processings.ExternalPersons
{
    public interface IExternalPersonProcessingService
    {
        ValueTask<List<ExternalPerson>> RetrieveFormattedExternalPersonsAsync();
    }
}