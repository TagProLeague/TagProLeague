using System.Collections.Generic;
using System.Threading.Tasks;
using TagProLeague.Models;

namespace TagProLeague.Services
{
    public interface ILeaguesRepository
    {
        Task<IEnumerable<League>> GetAllLeagues();
        Task<League> GetLeague(string name);
        Task CreateLeague(League league);
        Task<bool> UpdateLeague(League league);
        Task<bool> DeleteLeague(string name);
    }
}
