using System.Collections.Generic;
using System.Threading.Tasks;
using xChanger.Core.POC.Models.Foundations.ExternalPersons;

namespace xChanger.Core.POC.Services.Foundations.ExternalPersons
{
    public interface IExternalPersonService
    {
        ValueTask<List<ExternalPerson>> RetrieveAllExternalPersonsAsync();
    }
}
