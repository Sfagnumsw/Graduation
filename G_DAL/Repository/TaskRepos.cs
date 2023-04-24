using G_DAL.Entity;
using G_DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_DAL.Repository
{
    public class TaskRepos : IBaseAction<G_DAL.Entity.Task>
    {
        private readonly G_ContextDB _contextDB;
        public TaskRepos(G_ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public async System.Threading.Tasks.Task Create(G_DAL.Entity.Task obj)
        {
            await _contextDB.Task.AddAsync(obj);
            await _contextDB.SaveChangesAsync();
        }

        public async Task<G_DAL.Entity.Task> Get(int objId)
        {
            return await _contextDB.Task.FindAsync(objId);
        }

        public async Task<IEnumerable<G_DAL.Entity.Task>> GetAll() => await _contextDB.Task.ToListAsync();

        public async System.Threading.Tasks.Task Remove(int objId)
        {
            var local = _contextDB.Set<G_DAL.Entity.Task>().Local.FirstOrDefault(i => i.Id == objId);
            if (local != default)
            {
                _contextDB.Entry(local).State = EntityState.Detached;
            }
            _contextDB.Task.Remove(new G_DAL.Entity.Task { Id = objId });
            await _contextDB.SaveChangesAsync();
        }
    }
}
}
