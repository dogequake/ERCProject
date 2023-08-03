using ERCWeb.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using ERCWeb.Models;
using ERCWeb.Helpers;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;

namespace ERCWeb.Services
{
    public class LcService : ILcService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Lcs";

        public LcService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<LcModel>> ShowAll()
        {
            var response = await _client.GetAsync(BasePath);

            return await response.ReadContentAsync<List<LcModel>>();
        }

        public async Task<LcModel> ShowId(int id) 
        {
            var response = await _client.GetAsync($"{BasePath + "/" + id}");

            return await response.ReadContentAsync<LcModel>();
        }

        public async Task<LcModel> DeleteId(int id) 
        {
            var response = await _client.DeleteAsync($"{BasePath + "/" + id}");

            return await response.ReadContentAsync<LcModel>();
        }

        public async Task<LcModel> EditId(int id, LcModel model)
        {
            var response = await _client.PutAsJsonAsync($"{BasePath + "/" + id}", model);

            return await response.ReadContentAsync<LcModel>();
        }

        public async Task<LcModel> CreateNew(LcModel model) 
        {
            var response = await _client.PostAsJsonAsync(BasePath, model);

            return await response.ReadContentAsync<LcModel>();
        }

        //public async Task<IEnumerable<LcModel>> FindWithResident() 
        //{
        //    var response = await _client.GetAsync(BasePath);

        //    return await response.ReadContentAsync<List<LcModel>>();
        //}
    }
}
