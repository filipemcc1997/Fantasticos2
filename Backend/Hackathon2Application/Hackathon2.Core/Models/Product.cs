namespace Hackathon2.Core.Models
{
    public class Product
    {
        string Description { get; set; }

        int Sku { get; set; }

        string Brand { get; set; }

        string Category { get; set; }

        float MaxPrice { get; set; }

        int Upc { get; set; }

        int VatCode { get; set; }

        float SecondaryUnitPrice { get; set; }

        string SecondaryUnit { get; set; }
        string ImageUrl { get; set; }
    }
}
