namespace UltraPlayProject.Web.ViewModels.Match
{
    using System;
    using System.Collections.Generic;
    using UltraPlayProject.Data.Models;
    using UltraPlayProject.Web.Infrastructure.Mapping;
    using UltraPlayProject.Web.ViewModels.Bet;

    public class MatchViewModel : IMapFrom<Match>
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public string MatchType { get; set; }

        public int SportEventID { get; set; }

        public IEnumerable<BetViewModel> Bets { get; set; }
    }
}
