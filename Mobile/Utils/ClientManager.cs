using Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Utils
{
    public class ClientManager
    {
        private static readonly string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android
         ? "http://10.0.2.2:5145"
         : "http://localhost:5145";

        HttpClient _httpClient = new HttpClient();
        public async Task<Clients> GetClientByIdAsync(int clientId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiUrl}/api/Clients/{clientId}");
                if (response.IsSuccessStatusCode)
                {
                    var client = await response.Content.ReadFromJsonAsync<Clients>();
                    return client;
                }
                else
                {
                    throw new Exception("Client not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching the client: " + ex.Message);
            }

        }
    }
}