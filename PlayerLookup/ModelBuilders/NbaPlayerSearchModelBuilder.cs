using Microsoft.Extensions.Configuration;
using NbaApiClient.Interfaces;
using Newtonsoft.Json;
using PlayerLookup.Interfaces;
using PlayerLookup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlayerLookup.ModelBuilders
{
    public class NbaPlayerSearchModelBuilder : INbaPlayerSearchModelBuilder
    {
        private readonly IPlayersClient _playersClient;
        private readonly IConfiguration _config;
        public NbaPlayerSearchModelBuilder(IPlayersClient playersClient, IConfiguration configuration)
        {
            _playersClient = playersClient;
            _config = configuration;
        }

        public async Task<NbaPlayerSearchViewModel> BuildPlayerSearchViewModelFromSearchTerm(string searchTerm)
        {
            var viewModel = new NbaPlayerSearchViewModel()
            {
                SearchTerm = searchTerm
            };

            try
            {
                var searchResults = await _playersClient.SearchPlayersAsync(searchTerm, _config.GetValue<string>("NbaApiKey"));
                if (searchResults.data.Any())
                {
                    viewModel.Results = searchResults.data.ToList();
                }
                else
                {
                    viewModel.ErrorMessage = "No results when searching for: " + searchTerm;
                }
                
            }catch(HttpRequestException httpEx)
            {
                viewModel.ErrorMessage = "Player search API call failed: " + httpEx.Message;
                //logger.Error(httpEx);
            }
            catch (JsonException jsonEx)
            {
                viewModel.ErrorMessage = "Error deserializing JSON: " + jsonEx.Message;
                //logger.Error(jsonEx);
            }

            return viewModel;
        }
    }
}
