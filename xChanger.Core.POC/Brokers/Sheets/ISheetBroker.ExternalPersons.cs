using System.Collections.Generic;
using System.Threading.Tasks;
using xChanger.Core.POC.Models.Foundations.ExternalPersons;

namespace xChanger.Core.POC.Brokers.Sheets
{
    public partial interface ISheetBroker
    {
        ValueTask<List<ExternalPerson>> ReadAllExternalPersonsAsync();
    }
}
