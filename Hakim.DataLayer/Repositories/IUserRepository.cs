using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hakim.DataLayer.Repositories
{
    public interface IUserRepository:IHakimGenericRepository<User>
    {
        User GetUserByName(string name);
    }
}
