using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hackathon2.Core.Models
{
    public class Cart
    {
        [JsonPropertyName("username")]
        public string username { get; set; }
        [JsonPropertyName("sku")]
        public string SKU { get; set; }
    }
}
