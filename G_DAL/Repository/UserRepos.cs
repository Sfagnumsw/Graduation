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
    public class UserRepos : IBaseAction<User>
    {
        private readonly G_ContextDB _contextDB;
        public UserRepos(G_ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public async System.Threading.Tasks.Task Create(User obj)
        {
            await _contextDB.User.AddAsync(obj);
            await _contextDB.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task<User> Get(int objId)
        {
            return await _contextDB.User.FindAsync(objId);
        }

        public async System.Threading.Tasks.Task<IEnumerable<User>> GetAll() => await _contextDB.User.ToListAsync();

        public async System.Threading.Tasks.Task Remove(int objId)
        {
            var local = _contextDB.Set<User>().Local.FirstOrDefault(i => i.Id.Equals(objId));
            if (local != null)
            {
                _contextDB.Entry(local).State = EntityState.Detached;
            }
            _contextDB.User.Remove(new User() { Id = objId });
            await _contextDB.SaveChangesAsync();
        }
    }
}
