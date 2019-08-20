using NbaApiClient.ApiModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NbaApiClient.Interfaces
{
    public interface IPlayersClient
    {
        Task<NbaPlayerSearchResponse> SearchPlayersAsync(string searchTerm, string apiKey);
        Task<GetNbaGameStatsResponse> GetRecentStatsForPlayer(int playerId, string apiKey);
    }
}
