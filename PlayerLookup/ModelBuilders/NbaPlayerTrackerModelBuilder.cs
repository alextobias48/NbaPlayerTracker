using Microsoft.Extensions.Configuration;
using NbaApiClient.Interfaces;
using Newtonsoft.Json;
using PlayerLookup.Interfaces;
using PlayerLookup.Models;
using PlayerTrackerDataAccessor;
using PlayerTrackerDataAccessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlayerLookup.ModelBuilders
{

    public class NbaPlayerTrackerModelBuilder : INbaPlayerTrackerModelBuilder
    {
        private readonly IPlayersClient _playersClient;
        private readonly IPlayersFollowedDataAccessor _playersDbAccessor;
        private readonly IConfiguration _config;

        public NbaPlayerTrackerModelBuilder(IPlayersClient playersClient, IPlayersFollowedDataAccessor playersFollowedDataAccessor, IConfiguration configuration)
        {
            _playersClient = playersClient;
            _playersDbAccessor = playersFollowedDataAccessor;
            _config = configuration;
        }

        public async Task<NbaPlayerTrackerViewModel> BuildPlayerTrackerViewModel(int userId)
        {
            var viewModel = new NbaPlayerTrackerViewModel()
            {
                TrackedPlayers = new List<RecentPlayerStats>()
            };

            var myPlayers = _playersDbAccessor.GetPlayersForUser(userId);
            if (!myPlayers.Any())
            {
                viewModel.ErrorMessage = "You aren't tracking any players yet, search for players and add them to your list";
            }

            var random = new Random();
            foreach(var player in myPlayers)
            {
                var playerStats = new RecentPlayerStats()
                {
                    Player = player
                };
                try
                {
                    var stats = await _playersClient.GetRecentStatsForPlayer(player.id, _config.GetValue<string>("NbaApiKey"));
                    
                    //The free NbaAPI playerId filter doesn't work, so it just returns the same few games everytime...
                    //   picking the data at random for each player                    
                    playerStats.LatestStats = stats.data.ElementAtOrDefault(random.Next(0,stats.data.Count() -1));
                }
                catch (HttpRequestException httpEx)
                {
                    var log = "Player search API call failed: " + httpEx.Message;
                    viewModel.ErrorMessage = String.IsNullOrWhiteSpace(viewModel.ErrorMessage) ?  log : ", " + log;
                    //logger.Error(log);
                }
                catch (JsonException jsonEx)
                {
                    var log = "Error deserializing JSON: " + jsonEx.Message;
                    viewModel.ErrorMessage = String.IsNullOrWhiteSpace(viewModel.ErrorMessage) ? log : ", " + log;
                    //logger.Error(log);
                }
                viewModel.TrackedPlayers.Add(playerStats);
            }

            return viewModel;
        }
    }
}
