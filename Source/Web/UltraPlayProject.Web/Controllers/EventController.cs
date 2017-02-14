using System;
using System.Linq;
using System.Web.Mvc;
using UltraPlayProject.Data.Contracts;
using UltraPlayProject.Data.Models;
using UltraPlayProject.Web.Infrastructure.Mapping;
using UltraPlayProject.Web.ViewModels.Bet;
using UltraPlayProject.Web.ViewModels.Match;
using UltraPlayProject.Web.ViewModels.SportEvent;

namespace UltraPlayProject.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IGenericRepository<SportEvent> sportEventRepo;
        private readonly IGenericRepository<Match> matchRepo;

        public EventController(IGenericRepository<SportEvent> sportEventRepo, IGenericRepository<Match> matchRepo)
        {
            this.sportEventRepo = sportEventRepo;
            this.matchRepo = matchRepo;
        }

        public ActionResult Index(int? id)
        {
            var matches = this.matchRepo
                   .All
                   .Where(x => x.SportEvent.ID == id)
                   .To<MatchViewModel>()
                   .ToList()
                   .Where(x => x.StartDate.Subtract(DateTime.Now).CompareTo(TimeSpan.FromDays(1)) < 1)
                   .ToList();

            var viewModel = new SportEventViewModel()
            {
                Matches = matches,
                Name = this.sportEventRepo.GetById(id).Name
            };

            return this.View(viewModel);
        }
    }
}
