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
    public class StageRepos : IBaseAction<Stage>
    {
        private readonly G_ContextDB _contextDB;
        public StageRepos(G_ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public async System.Threading.Tasks.Task<Stage> Create(Stage obj)
        {
            var entity = await _contextDB.Stage.AddAsync(obj);
            await _contextDB.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task<Stage> Get(int objId)
        {
            return await _contextDB.Stage.FirstOrDefaultAsync(i => i.Id == objId);
        }

        public async Task<IEnumerable<Stage>> GetAll() => await _contextDB.Stage.ToListAsync();

        public async System.Threading.Tasks.Task Remove(int objId)
        {
            var local = _contextDB.Set<Stage>().Local.FirstOrDefault(i => i.Id == objId);
            if (local != default)
            {
                _contextDB.Entry(local).State = EntityState.Detached;
            }
            _contextDB.Stage.Remove(new Stage { Id = objId });
            await _contextDB.SaveChangesAsync();
        }
    }
}
