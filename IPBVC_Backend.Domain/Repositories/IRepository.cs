using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IPBVC_Backend.Domain.Repositories
{
    public interface IRepository
    {
            void Add<T>(T entity) where T : class;
            void Update<T>(T entity) where T : class;
            void Delete<T>(int id) where T : class;
            Task<bool> SaveChangesAsync();

            Task<bool> Exists<T>(Expression<Func<T, bool>> predicate) where T : class;
            void MarkPropertyAsModified<T>(T entity, string propertyName) where T : class;
            IDbContextTransaction BeginTransaction();
        }
}
