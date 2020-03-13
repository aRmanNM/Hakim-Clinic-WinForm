using Hakim.DataLayer.Repositories;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hakim.DataLayer.Services
{
    public class VisitReceptionRepository : HakimGenericRepository<VisitReception>, IVisitReceptionRepository
    {
        public VisitReceptionRepository(DB_HakimEntities _context) : base(_context)
        {
        }

        public IEnumerable<VisitReception> GetWithPredicate(Expression<Func<VisitReception, bool>> filter = null)
        {
            IQueryable<VisitReception> query = dbSet;

            if (filter != null)
            {
                query = query.AsExpandable().Where(filter);
            }            
            
            return query.ToList();            
        }
    }
}
