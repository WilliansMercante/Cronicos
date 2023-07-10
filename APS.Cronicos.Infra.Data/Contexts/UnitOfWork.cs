using APS.Cronicos.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APS.Cronicos.Infra.Data.Contexts
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        private readonly TContext _context;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.Log();
            _context.SaveChanges();
        }
    }
}
