using NbaApiClient.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerLookup.Models
{
    public class NbaPlayerTrackerViewModel
    {
        public NbaPlayerTrackerViewModel()
        {
            TrackedPlayers = new List<RecentPlayerStats>();
        }
        public List<RecentPlayerStats> TrackedPlayers {get;set;}
        public string ErrorMessage { get; set; }
    }

    public class RecentPlayerStats
    {
        public NbaPlayer Player { get; set; }
        public NbaGameStats LatestStats { get; set; }
    }

}
