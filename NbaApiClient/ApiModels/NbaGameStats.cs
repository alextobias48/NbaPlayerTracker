using System;
using System.Collections.Generic;
using System.Text;

namespace NbaApiClient.ApiModels
{
    public class GetNbaGameStatsResponse
    {
        public NbaGameStats[] data { get; set; }
        public PlayerSearchMetaData meta { get; set; }
    }

    public class NbaGameStats
    {
        public int id { get; set; }
        public int ast { get; set; }
        public int blk { get; set; }
        public int dreb { get; set; }
        public double fg3_pct { get; set; }
        public int fg3a { get; set; }
        public int fg3m { get; set; }
        public double ft_pct { get; set; }
        public int fta { get; set; }
        public int ftm { get; set; }
        public string min { get; set; }
        public int oreb { get; set; }
        public int pf { get; set; }
        public int pts { get; set; }
        public int reb { get; set; }
        public int stl { get; set; }
        public int turnover { get; set; }
        public NbaGame game { get; set; }
    }
}
