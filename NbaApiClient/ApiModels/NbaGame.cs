using System;
using System.Collections.Generic;
using System.Text;

namespace NbaApiClient.ApiModels
{
    public class NbaGame
    {
        public int id { get; set; }
        public DateTimeOffset date { get; set; }
        public int home_team_id { get; set; }
        public int home_team_score { get; set; }
        public int visitor_team_id { get; set; }
        public int visitor_team_score { get; set; }
    }
}
