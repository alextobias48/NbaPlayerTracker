using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NbaApiClient.ApiModels;
using PlayerLookup.Interfaces;
using PlayerLookup.Models;
using PlayerTrackerDataAccessor.Interfaces;

namespace PlayerLookup.Controllers
{
    public class PlayerSearchController : Controller
    {
        private readonly IPlayersFollowedDataAccessor _playersFollowedDataAccessor;
        private readonly INbaPlayerTrackerModelBuilder _nbaPlayerTrackerModelBuilder;
        private readonly INbaPlayerSearchModelBuilder _nbaPlayerSearchModelBuilder;
        public PlayerSearchController(IPlayersFollowedDataAccessor playersFollowedDataAccessor, INbaPlayerSearchModelBuilder nbaPlayerSearchModelBuilder, INbaPlayerTrackerModelBuilder nbaPlayerTrackerModelBuilder)
        {
            _playersFollowedDataAccessor = playersFollowedDataAccessor;
            _nbaPlayerSearchModelBuilder = nbaPlayerSearchModelBuilder;
            _nbaPlayerTrackerModelBuilder = nbaPlayerTrackerModelBuilder;
        }

        public ActionResult Index()
        {
            return View("PlayerSearch", new NbaPlayerSearchViewModel());
        }

        public async Task<ActionResult> Search(NbaPlayerSearchViewModel search)
        {
            var viewModel = await _nbaPlayerSearchModelBuilder.BuildPlayerSearchViewModelFromSearchTerm(search.SearchTerm);
            return View("PlayerSearch", viewModel);
        }
        
        public async Task<ActionResult> TrackPlayer(NbaPlayer player)
        {
            _playersFollowedDataAccessor.AddPlayerForUser(1, player);
            var trackerViewModel = await _nbaPlayerTrackerModelBuilder.BuildPlayerTrackerViewModel(1);
            return View("PlayerTracker", trackerViewModel);
        }
    }
}