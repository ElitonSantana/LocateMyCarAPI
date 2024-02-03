using LocateMyCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LocateMyCar.Domain.Services.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll(params Expression<Func<T, object>>[]? include);
        T GetById(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[]? include);
        void Create(T entity);
        void Update(T entity);
        void Delete(object id);
        void Save();
        List<VehicleVM> GetTopVehiclesOlders();
    }
}
