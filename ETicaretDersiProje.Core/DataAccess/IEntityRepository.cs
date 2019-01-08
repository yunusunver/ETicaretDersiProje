using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ETicaretDersiProje.Core.Entities;

namespace ETicaretDersiProje.Core.DataAccess
{
    public interface IEntityRepository<T> where T:class ,IEntity,new()
    {
        List<T> GetList(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T,bool>> filter);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        
    }
}
