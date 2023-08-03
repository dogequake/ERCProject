using ERCWeb.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using ERCWeb.Services.Interfaces;
using ERCWeb.Helpers;
using System.Net.Http.Json;

namespace ERCWeb.Services
{
    public class ResidentService : IResidentService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/residents";

        public ResidentService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ResidentModel>> ShowAll()
        {
            var response = await _client.GetAsync(BasePath);

            return await response.ReadContentAsync<List<ResidentModel>>();
        }

        public async Task<ResidentModel> CreateNew(ResidentModel model)
        {
            var response = await _client.PostAsJsonAsync(BasePath, model);

            return await response.ReadContentAsync<ResidentModel>();
        }
    }
}
