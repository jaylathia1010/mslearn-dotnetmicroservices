using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using backend.Dtos;
using Microsoft.Extensions.Configuration;

namespace backend.SyncDataServices.Http
{
    public class HttpReportDataClient : IReportDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpReportDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendPizzaToReport(PizzaReadDto pizza)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(pizza),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync($"{_configuration["ReportsService"]}/Reports/PizzaDetail", httpContent);

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