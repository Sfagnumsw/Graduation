using G_DAL.Entity;
using G_DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_DAL.Repository
{
    public class StatusRepos : IBaseAction<Status>
    {
        private readonly G_ContextDB _contextDB;
        public StatusRepos(G_ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public async System.Threading.Tasks.Task<Status> Create(Status obj)
        {
            var entity = await _contextDB.Status.AddAsync(obj);
            await _contextDB.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task<Status> Get(int objId)
        {
            return await _contextDB.Status.FirstOrDefaultAsync(i => i.Id == objId);
        }

        public async Task<IEnumerable<Status>> GetAll() => await _contextDB.Status.ToListAsync();

        public async System.Threading.Tasks.Task Remove(int objId)
        {
            var local = _contextDB.Set<Status>().Local.FirstOrDefault(i => i.Id == objId);
            if (local != default)
            {
                _contextDB.Entry(local).State = EntityState.Detached;
            }
            _contextDB.Status.Remove(new Status { Id = objId });
            await _contextDB.SaveChangesAsync();
        }
    }
}
