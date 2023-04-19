using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace HetkoFrontEnd.Gateways
{
    public class APIGateway
    {
        HttpClient _httpClient;
        public APIGateway(HttpClient httpClient)
        {
            _httpClient = httpClient;   
        }

        public async Task<List<Models.Product>> GetProducts()
        {
            var products = await _httpClient.GetAsync("https://hackathon2backend.azurewebsites.net/GetProducts");
            if(products != null)
            {
                var json =  await products.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Models.Product>>(json);
            }
            return null;
        }


    }
}
