namespace Hackathon2.Core.Models
{
    public class Product
    {
        public string description { get; set; }

        public int SKU { get; set; }

        public string DisplayName { get; set; }
        public string brand { get; set; }

        public string category { get; set; }

        public decimal MaxPrice { get; set; }

        public int Upc { get; set; }

        public int VatCode { get; set; }

        public decimal secondaryUnitPrice { get; set; }

        public string SecondaryUnit { get; set; }

        public string urlImagem { get; set; }
    }
}
