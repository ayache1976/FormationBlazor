using Cloudcrate.AspNetCore.Blazor.Browser.Storage;
using Initiation.Shared.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Initiation.Client.Services.Http
{
    public interface IHttpUserService
    {
        Task<HttpResponseMessage> PostRegister(DtoUser dto);
        Task<HttpResponseMessage> PostLogin(DtoUser dto);
        Task<bool> PostAvailable(DtoUserForLogin dto);

    }
    public class HttpUserService : IHttpUserService
    {
        private readonly HttpClient _httpClient;
        private readonly LocalStorage _storage;
        public HttpUserService(HttpClient httpClient, LocalStorage storage)
        {
            _httpClient = httpClient;
            _storage = storage;
        }
        public async Task<bool> PostAvailable(DtoUserForLogin dto)
        {
            var swAvailable = false;
            if (dto.UserName == "" || dto.UserName.Length <= 2 || dto.UserName.Length > 30)
                return swAvailable;
            var reqJson = JsonConvert.SerializeObject(dto);
            using (var req = new HttpRequestMessage(HttpMethod.Post, $"{Constants.Base_URL}api/User/available"))
            {
                req.Content = new StringContent(reqJson, Encoding.Default, "application/json");
                using (var response = await _httpClient.SendAsync(req))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                        swAvailable = Convert.ToBoolean(await response.Content.ReadAsStringAsync());
                }
            }
            return swAvailable;
        }

        public async Task<HttpResponseMessage> PostLogin(DtoUser dto)
        {
            _storage.RemoveItem("token");
            _storage.RemoveItem("username");
            var reqJson = JsonConvert.SerializeObject(dto);
            using (var req = new HttpRequestMessage(HttpMethod.Post, $"{Constants.Base_URL}api/User/login"))
            {
                req.Content = new StringContent(reqJson, Encoding.Default, "application/json");
                var response = await _httpClient.SendAsync(req);
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var dtoFromResponse = JsonConvert.DeserializeObject<DtoUserForLogin>(content);
                    _storage["token"] = dtoFromResponse.Token;
                    _storage["username"] = dtoFromResponse.UserName;
                }
                return response;
            }
        }

        public async Task<HttpResponseMessage> PostRegister(DtoUser dto)
        {
            var reqJson = JsonConvert.SerializeObject(dto);
            using(var req = new HttpRequestMessage(HttpMethod.Post, $"{Constants.Base_URL}api/User/register"))
            {
                req.Content = new StringContent(reqJson, Encoding.Default, "application/json");
                return await _httpClient.SendAsync(req);
            }
        }
    }
}
