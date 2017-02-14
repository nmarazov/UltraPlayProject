namespace UltraPlayProject.Web.ViewModels.SportEvent
{
    using System.Collections.Generic;
    using Data.Models;
    using UltraPlayProject.Web.Infrastructure.Mapping;
    using UltraPlayProject.Web.ViewModels.Match;

    public class SportEventViewModel : IMapFrom<SportEvent>
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public bool IsLive { get; set; }

        public int CategoryID { get; set; }

        public int SportID { get; set; }

        public  Sport Sport { get; set; }

        public IEnumerable<MatchViewModel> Matches { get; set; }
    }
}
