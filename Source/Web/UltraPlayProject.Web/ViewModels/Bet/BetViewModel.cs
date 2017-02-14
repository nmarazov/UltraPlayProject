namespace UltraPlayProject.Web.ViewModels.Bet
{
    using System.Collections.Generic;
    using UltraPlayProject.Data.Models;
    using UltraPlayProject.Web.Infrastructure.Mapping;

    public class BetViewModel : IMapFrom<Data.Models.Bet>
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public bool IsLive { get; set; }

        public virtual int MatchID { get; set; }

        public IEnumerable<Odd> Odds { get; set; }
    }
}
