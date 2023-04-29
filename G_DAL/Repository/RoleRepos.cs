using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G_DAL.Entity;
using G_DAL.Interface;
using Microsoft.EntityFrameworkCore;

namespace G_DAL.Repository
{
    internal class RoleRepos : IBaseAction<Role>
    {
        private readonly G_ContextDB _contextDB;
        public RoleRepos(G_ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public async System.Threading.Tasks.Task<Role> Create(Role obj)
        {
            var entity = await _contextDB.Role.AddAsync(obj);
            await _contextDB.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task<Role> Get(int objId)
        {
            return await _contextDB.Role.FirstOrDefaultAsync(i => i.Id == objId);
        }

        public async Task<IEnumerable<Role>> GetAll() => await _contextDB.Role.ToListAsync();

        public async System.Threading.Tasks.Task Remove(int objId)
        {
            var local = _contextDB.Set<Role>().Local.FirstOrDefault(i => i.Id == objId);
            if(local != default)
            {
                _contextDB.Entry(local).State = EntityState.Detached;
            }
            _contextDB.Role.Remove(new Role { Id = objId });
            await _contextDB.SaveChangesAsync();
        }
    }
}
