using Hackathon2.Core.Interfaces.Repositories;
using Hackathon2.Core.Models;

namespace Hackathon2.Infrastructure.Repositories
{
    public class HackathonRepository : IHackathonRepository
    {
        List<Product> IHackathonRepository.GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
