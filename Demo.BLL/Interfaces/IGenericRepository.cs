using Demo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IGenericRepository<T>  where T : BaseEntity
    {
        void Add(T entity);
        T GetById(int? id);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
    }
}
