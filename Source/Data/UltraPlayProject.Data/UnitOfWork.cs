namespace UltraPlayProject.Data
{
    using System;
    using UltraPlayProject.Data.Contracts;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IUltraPlayDbContext context;

        public UnitOfWork(IUltraPlayDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }

            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
