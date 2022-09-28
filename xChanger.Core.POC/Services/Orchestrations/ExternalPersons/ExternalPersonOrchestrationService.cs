using System.Collections.Generic;
using System.Threading.Tasks;
using xChanger.Core.POC.Models.Foundations.ExternalPersons;
using xChanger.Core.POC.Services.Processings.ExternalPersons;

namespace xChanger.Core.POC.Services.Orchestrations.ExternalPersons
{
    public class ExternalPersonOrchestrationService : IExternalPersonOrchestrationService
    {
        private readonly IExternalPersonProcessingService externalPersonProcessingService;

        public ExternalPersonOrchestrationService(IExternalPersonProcessingService externalPersonProcessingService)
        {
            this.externalPersonProcessingService = externalPersonProcessingService;
        }

        public ValueTask<List<ExternalPerson>> RetrieveFormattedExternalPersonsAsync() =>
            this.externalPersonProcessingService.RetrieveFormattedExternalPersonsAsync();
    }
}
