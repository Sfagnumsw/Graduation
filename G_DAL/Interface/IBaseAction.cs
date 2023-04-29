using G_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_DAL.Interface
{
    public interface IBaseAction<T> where T : BaseEntity
    {
        System.Threading.Tasks.Task<T> Create(T obj);
        System.Threading.Tasks.Task<T> Get(int objId);
        System.Threading.Tasks.Task<IEnumerable<T>> GetAll();
        System.Threading.Tasks.Task Remove(int objId);
    }
}
