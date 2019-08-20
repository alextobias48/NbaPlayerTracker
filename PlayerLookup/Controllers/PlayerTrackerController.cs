using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayerLookup.Interfaces;

namespace PlayerLookup.Controllers
{
    public class PlayerTrackerController : Controller
    {
        private readonly INbaPlayerTrackerModelBuilder _nbaPlayerTrackerModelBuilder;
        public PlayerTrackerController(INbaPlayerTrackerModelBuilder nbaPlayerTrackerModelBuilder)
        {
            _nbaPlayerTrackerModelBuilder = nbaPlayerTrackerModelBuilder;
        }

        public async Task<IActionResult> Index()
        {
            var trackerViewModel = await _nbaPlayerTrackerModelBuilder.BuildPlayerTrackerViewModel(1);
            return View("PlayerTracker",trackerViewModel);
        }
    }
}