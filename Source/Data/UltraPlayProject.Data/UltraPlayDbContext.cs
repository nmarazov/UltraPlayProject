using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace UltraPlayProject.Data
{
    using System.Data.Entity;
    using UltraPlayProject.Data.Contracts;
    using UltraPlayProject.Data.Models;

    public class UltraPlayDbContext : DbContext, IUltraPlayDbContext
    {
        public UltraPlayDbContext()
            : base("UltraPlayDbConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UltraPlayDbContext>());
        }

        public virtual IDbSet<XmlSports> XmlSports { get; set; }

        public virtual IDbSet<Sport> Sports { get; set; }

        public virtual IDbSet<SportEvent> SportEvents { get; set; }

        public virtual IDbSet<Match> Matches { get; set; }

        public virtual IDbSet<Bet> Bets { get; set; }

        public virtual IDbSet<Odd> Odds { get; set; }

        public new IDbSet<T> Set<T>()
            where T : class
        {
            return base.Set<T>();
        }

        [OnDeserialized]
        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
