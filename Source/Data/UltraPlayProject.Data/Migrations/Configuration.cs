namespace UltraPlayProject.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<UltraPlayDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(UltraPlayDbContext context)
        {
        }
    }
}
