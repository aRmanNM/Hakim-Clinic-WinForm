using Hakim.DataLayer.Repositories;
using Hakim.DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hakim.DataLayer.Context
{
    public interface IHakimUnitOfWork
    {
        UserRepository Users { get; }
        IHakimGenericRepository<Doctor> Doctors  { get; }
        IHakimGenericRepository<Insurance> Insurances { get; }
        IHakimGenericRepository<Service> Services { get; }
        IHakimGenericRepository<Role> Roles { get; }
        IHakimGenericRepository<ServiceGroup> ServiceGroups { get; }
        VisitReceptionRepository VisitReceptions { get; }
        IHakimGenericRepository<ServiceReception> ServiceReceptions { get; }
    }
}
