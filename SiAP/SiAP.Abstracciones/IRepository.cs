using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiAP.Abstracciones
{
    public interface IRepository<T>
    {
        T Create(T entity); // Expression<Func<T, bool>> filter
        T Read(T entity);
        T Update(T entity);
        T Delete(T entity);

        bool Create(List<T> lista, T entity); // Expression<Func<T, bool>> filter
        T Read(List<T> lista);
        bool Update(List<T> lista);
        bool Delete(List<T> lista);
    }
}
