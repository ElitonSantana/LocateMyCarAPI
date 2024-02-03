using LocateMyCar.Domain.Entities;
using LocateMyCar.Domain.Services.Interfaces;
using LocateMyCar.Infra.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LocateMyCar.Infra.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _Context;
        private readonly DbSet<T> _DbSet;
        private readonly string _connectionString;
        public Repository(ApplicationDbContext Context, IConfiguration configuration)
        {
            _Context = Context;
            _DbSet = Context.Set<T>();
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[]? include)
        {
            if (include != null)
            {
                IQueryable<T> query = _DbSet.AsQueryable();

                foreach (var includeProperty in include)
                {
                    query = query.Include(includeProperty);
                }

                return query.AsQueryable();
            }
            return _DbSet.AsQueryable();
        }
        public T GetById(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[]? include)
        {
            if (include != null)
            {
                IQueryable<T> query = _DbSet.AsQueryable();

                foreach (var includeProperty in include)
                {
                    query = query.Include(includeProperty);
                }

                return query.FirstOrDefault(where);

            }
            else
                return _DbSet.FirstOrDefault(where);
        }

        public void Create(T entity)
        {
            SetPropertyValue(entity, "CreationDate", DateTime.Now);
            _DbSet.Add(entity);
            _Context.Add(entity);
            Save();
        }

        public void Update(T entity)
        {
            SetPropertyValue(entity, "ModifiedDate", DateTime.Now);
            _DbSet.Update(entity);
            Save();
        }

        public void Delete(object id)
        {
            T entityToDelete = _DbSet.Find(id);
            if (entityToDelete != null)
                _DbSet.Remove(entityToDelete);
            Save();
        }

        public void Save()
        {
            _Context.SaveChanges();
        }
        private void SetPropertyValue<T>(T obj, string propertyName, object value)
        {
            var property = obj.GetType().GetProperty(propertyName);

            if (property != null)
                property.SetValue(obj, value);
            else
                throw new ArgumentException($"A propriedade {propertyName} não existe em {typeof(T).Name}.");
        }
        public List<VehicleVM> GetTopVehiclesOlders()
        {
            List<VehicleVM> resultList = new List<VehicleVM>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_GetTopVehiclesOlders", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VehicleVM result = new VehicleVM
                            {
                                ImageURL = reader["ImageURL"].ToString(),
                                FullName = reader["FullName"].ToString(),
                                Year = Convert.ToInt32(reader["Year"]),
                                Price = Convert.ToDouble(reader["Price"]),
                            };

                            resultList.Add(result);
                        }
                    }
                }
            }
            return resultList;
        }
    }
}
