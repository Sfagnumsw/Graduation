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
    public class ProjectRepos : IBaseAction<Project>
    {
        private readonly G_ContextDB _contextDB;
        public ProjectRepos(G_ContextDB contextDB) 
        { 
            _contextDB = contextDB;
        }

        public async System.Threading.Tasks.Task Create(Project obj)
        {
            if (obj.Id == default)
            {
                _contextDB.Entry(obj).State = EntityState.Added;
            }
            else
            {
                _contextDB.Entry(obj).State = EntityState.Modified;
            }
            await _contextDB.SaveChangesAsync();
        }

        public async Task<Project> Get(int objId)
        {
            return await _contextDB.Project.FirstOrDefaultAsync(i => i.Id == objId);
        }

        public async Task<IEnumerable<Project>> GetAll() => await _contextDB.Project.ToListAsync();

        public async System.Threading.Tasks.Task Remove(int objId)
        {
            var local = _contextDB.Set<Project>().Local.FirstOrDefault(i => i.Id.Equals(objId));
            if (local != null)
            {
                _contextDB.Entry(local).State = EntityState.Detached;
            }
            _contextDB.Project.Remove(new Project() { Id = objId });
            await _contextDB.SaveChangesAsync();
        }
    }
}
