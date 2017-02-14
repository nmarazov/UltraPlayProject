namespace UltraPlayProject.Web.ViewModels.Sport
{
    using System.Collections.Generic;
    using Data.Models;
    using UltraPlayProject.Web.Infrastructure.Mapping;
    using UltraPlayProject.Web.ViewModels.SportEvent;

    public class SportViewModel : IMapFrom<Sport>
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public IEnumerable<SportEventViewModel> SportEvents { get; set; }
    }
}
