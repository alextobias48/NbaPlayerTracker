using PlayerLookup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerLookup.Interfaces
{
    public interface INbaPlayerTrackerModelBuilder
    {
        Task<NbaPlayerTrackerViewModel> BuildPlayerTrackerViewModel(int userId);
    }
}
