using Hakim.DataLayer.Repositories;
using Hakim.DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hakim.DataLayer.Context
{
    public class HakimUnitOfWork:IDisposable, IHakimUnitOfWork
    {
        private DB_HakimEntities db = new DB_HakimEntities();

        private UserRepository _users;
        public UserRepository Users => _users ?? new UserRepository(db);

        private HakimGenericRepository<Doctor> _doctors;
        public IHakimGenericRepository<Doctor> Doctors => _doctors ?? new HakimGenericRepository<Doctor>(db);

        private HakimGenericRepository<Insurance> _insurances;
        public IHakimGenericRepository<Insurance> Insurances => _insurances ?? new HakimGenericRepository<Insurance>(db);

        private HakimGenericRepository<Service> _services;
        public IHakimGenericRepository<Service> Services => _services ?? new HakimGenericRepository<Service>(db);

        private HakimGenericRepository<Role> _roles;
        public IHakimGenericRepository<Role> Roles => _roles ?? new HakimGenericRepository<Role>(db);

        private HakimGenericRepository<ServiceGroup> _serviceGroups;
        public IHakimGenericRepository<ServiceGroup> ServiceGroups => _serviceGroups ?? new HakimGenericRepository<ServiceGroup>(db);

        private VisitReceptionRepository _visitReceptions;
        public VisitReceptionRepository VisitReceptions => _visitReceptions ?? new VisitReceptionRepository(db);

        private HakimGenericRepository<ServiceReception> _serviceReceptions;
        public IHakimGenericRepository<ServiceReception> ServiceReceptions => _serviceReceptions ?? new HakimGenericRepository<ServiceReception>(db);

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
