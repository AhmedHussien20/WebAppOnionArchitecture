using DomainLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace InfrastructureLayer.RespositoryPattern
{
    public interface IRepository<T> where T : BaseEntity
    { 
        IQueryable<T> GetAll();
        T Get(int Id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
