using NbaApiClient.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerLookup.Models
{
    public class NbaPlayerSearchViewModel
    {
        public NbaPlayerSearchViewModel()
        {
            Results = new List<NbaPlayer>();
        }
        public string SearchTerm { get; set; }
        public List<NbaPlayer> Results { get; set; }
        public string ErrorMessage { get; set; }
    }
}
