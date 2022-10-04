using System.Threading.Tasks;
using backend.Dtos;

namespace backend.SyncDataServices.Http
{
    public interface IReportDataClient
    {
        Task SendPizzaToReport(PizzaReadDto pizza);
    }
}