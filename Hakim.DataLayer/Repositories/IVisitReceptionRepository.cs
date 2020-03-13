using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hakim.DataLayer.Repositories
{
    interface IVisitReceptionRepository:IHakimGenericRepository<VisitReception>
    {
        IEnumerable<VisitReception> GetWithPredicate(Expression<Func<VisitReception, bool>> filter = null);
    }
}
