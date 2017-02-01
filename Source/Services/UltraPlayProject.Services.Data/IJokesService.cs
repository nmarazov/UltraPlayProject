namespace UltraPlayProject.Services.Data
{
    using System.Linq;

    using UltraPlayProject.Data.Models;

    public interface IJokesService
    {
        IQueryable<Joke> GetRandomJokes(int count);

        Joke GetById(string id);
    }
}
