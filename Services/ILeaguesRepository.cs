using System.Collections.Generic;
using System.Threading.Tasks;
using TagProLeague.Models;

namespace TagProLeague.Services
{
    public interface ILeaguesRepository
    {
        Task<IEnumerable<MongoDbLeague>> GetAllLeagues();
        Task<MongoDbLeague> GetLeague(string name);
        Task CreateLeague(MongoDbLeague league);
        Task<bool> UpdateLeague(MongoDbLeague league);
        Task<bool> DeleteLeague(string name);
    }
}
