using Hakim.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hakim.DataLayer.Services
{

    public class UserRepository : HakimGenericRepository<User>, IUserRepository
    {        
        public UserRepository(DB_HakimEntities _context) : base(_context)
        {            
        }
        public User GetUserByName(string name)
        {
            return dbSet.First(n => n.UserName == name);
        }
    }
}
