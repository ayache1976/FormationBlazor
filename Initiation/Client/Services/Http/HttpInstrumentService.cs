using Cloudcrate.AspNetCore.Blazor.Browser.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Initiation.Client.Services.Http
{
    public interface IHttpInstrumentService
    {
        Task<HttpResponseMessage> GetInstrumentsPaged(int page);
    }
    public class HttpInstrumentService : IHttpInstrumentService
    {
        private readonly HttpClient _httpClient;
        private readonly LocalStorage _storage;
        public HttpInstrumentService(HttpClient httpClient, LocalStorage storage) 
        { 
            _httpClient = httpClient;
            _storage = storage;
        }
        public async Task<HttpResponseMessage> GetInstrumentsPaged(int page)
        {
            var req = new HttpRequestMessage(HttpMethod.Get, $"{Constants.Base_URL}api/Instrument/Paged?pageNumber={page}");
            var token = _storage["token"];
            req.Headers.Add("Authorization", $"Bearer {token}");
            return await _httpClient.SendAsync(req);
        }
    }
}
