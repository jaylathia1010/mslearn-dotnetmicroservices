using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using backend.Dtos;

namespace backend.SyncDataServices.Http
{
    public class HttpReportDataClient : IReportDataClient
    {
        private readonly HttpClient _httpClient;

        public HttpReportDataClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendPizzaToReport(PizzaReadDto pizza)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(pizza),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync("http://localhost:5195/api/Reports/PizzaDetail", httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("The PizzaService call to Report data is SUCCESSFUL..!");
            }
            else
            {
                Console.WriteLine("The PizzaService call to Report data is FAILED..!");
            }
        }
    }
}