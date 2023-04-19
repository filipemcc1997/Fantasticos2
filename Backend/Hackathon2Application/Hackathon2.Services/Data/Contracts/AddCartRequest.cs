using Hackathon2.Core.Models;
using System.Text.Json.Serialization;

namespace Hackathon2.Services.Data.Contracts
{
    public class AddCartRequest
    {
        [JsonPropertyName("cart")]
        public List<Cart> Cart { get; set; }
    }
}
