using Hackathon2.Core.Models;

namespace Hackathon2.Core.Interfaces.Repositories
{
    public interface IHackathonRepository
    {
        Task<List<Product>> GetProductsAsync();
    }
}
