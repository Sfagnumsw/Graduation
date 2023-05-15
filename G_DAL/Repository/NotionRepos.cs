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
    public class NotionRepos : IBaseAction<Notion>
    {
        private readonly G_ContextDB _contextDB;
        public NotionRepos(G_ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public async System.Threading.Tasks.Task Create(Notion obj)
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

        public async Task<Notion> Get(int objId)
        {
            return await _contextDB.Notion.FirstOrDefaultAsync(i => i.Id == objId);
        }

        public async Task<IEnumerable<Notion>> GetAll() => await _contextDB.Notion.ToListAsync();

        public async System.Threading.Tasks.Task Remove(int objId)
        {
            var local = _contextDB.Set<Notion>().Local.FirstOrDefault(i => i.Id == objId);
            if (local != default)
            {
                _contextDB.Entry(local).State = EntityState.Detached;
            }
            _contextDB.Notion.Remove(new Notion { Id = objId });
            await _contextDB.SaveChangesAsync();
        }
    }
}
