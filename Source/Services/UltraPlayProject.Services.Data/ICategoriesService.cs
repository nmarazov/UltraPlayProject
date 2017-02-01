namespace UltraPlayProject.Services.Data
{
    using System.Linq;

    using UltraPlayProject.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<JokeCategory> GetAll();

        JokeCategory EnsureCategory(string name);
    }
}
