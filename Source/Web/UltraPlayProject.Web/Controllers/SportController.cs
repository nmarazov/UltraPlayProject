namespace UltraPlayProject.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Contracts;
    using UltraPlayProject.Data.Models;
    using UltraPlayProject.Web.Infrastructure.Mapping;
    using UltraPlayProject.Web.ViewModels.Sport;
    using UltraPlayProject.Web.ViewModels.SportEvent;

    public class SportController : Controller
    {
        private readonly IGenericRepository<Sport> sportRepo;
        private readonly IGenericRepository<SportEvent> sportEventRepo;

        public SportController(IGenericRepository<Sport> sportRepo, IGenericRepository<SportEvent> sportEventRepo)
        {
            this.sportRepo = sportRepo;
            this.sportEventRepo = sportEventRepo;
        }

        public ActionResult Index()
        {
            var sports = this.sportRepo.All.To<SportViewModel>().ToList();

            var viewModel = new IndexViewModel
            {
                Sports = sports
            };

            return this.View(viewModel);
        }

        public ActionResult ById(int? id)
        {
            var sportEvents = this.sportEventRepo
                .All
                .Where(x => x.SportID == id)
                .To<SportEventViewModel>()
                .ToList();

            var viewModel = new SportViewModel()
            {
                SportEvents = sportEvents,
                Name = this.sportRepo.GetById(id).Name
            };

            return this.View(viewModel);
        }
    }
}
