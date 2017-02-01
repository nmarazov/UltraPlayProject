namespace UltraPlayProject.Web.ViewModels.Home
{
    using UltraPlayProject.Data.Models;
    using UltraPlayProject.Web.Infrastructure.Mapping;

    public class JokeCategoryViewModel : IMapFrom<JokeCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
