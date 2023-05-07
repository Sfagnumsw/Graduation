using G_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_Service.Interface
{
    public interface IBaseService<T>
    {
        System.Threading.Tasks.Task Create(T model);
        System.Threading.Tasks.Task Remove(int objId);
        Task<T> Get(int objId);
        Task<IEnumerable<T>> GetAll();
    }
}
