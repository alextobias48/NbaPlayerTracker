using System;
using System.Collections.Generic;
using System.Text;

namespace NbaApiClient.ApiModels
{
    public class NbaPlayerSearchResponse
    {
        public NbaPlayer[] data { get; set; }
        public PlayerSearchMetaData meta { get; set; }
    }

    public class NbaPlayer
    {
        public NbaPlayer()
        {
            height_feet = "N/A";
            height_inches = "N/A";
            weight_pounds = "N/A";
        }
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string height_feet { get; set; }
        public string height_inches { get; set; }
        public string weight_pounds { get; set; }
        public string position { get; set; }
        public NbaTeam team { get; set; }
    }

    public class PlayerSearchMetaData
    {
        public int total_pages { get; set; }
        public int current_page { get; set; }
        public int next_page { get; set; }
        public int per_page { get; set; }
        public int total_count { get; set; }
    }
}
