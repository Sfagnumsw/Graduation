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
    public class TeamRepos : IBaseAction<Team>
    {
        private readonly G_ContextDB _contextDB;
        public TeamRepos(G_ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public async System.Threading.Tasks.Task Create(Team obj)
        {
            await _contextDB.Team.AddAsync(obj);
            await _contextDB.SaveChangesAsync();
        }

        public async Task<Team> Get(int objId)
        {
            return await _contextDB.Team.FindAsync(objId);
        }

        public async Task<IEnumerable<Team>> GetAll() => await _contextDB.Team.ToListAsync();

        public async System.Threading.Tasks.Task Remove(int objId)
        {
            var local = _contextDB.Set<Team>().Local.FirstOrDefault(i => i.Id == objId);
            if (local != default)
            {
                _contextDB.Entry(local).State = EntityState.Detached;
            }
            _contextDB.Team.Remove(new Team { Id = objId });
            await _contextDB.SaveChangesAsync();
        }
    }
}
