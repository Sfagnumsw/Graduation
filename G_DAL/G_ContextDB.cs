using G_DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_DAL
{
    public class G_ContextDB : DbContext
    {
        public G_ContextDB(DbContextOptions<G_ContextDB> opt) : base(opt) { }

        public DbSet<Project> Project { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Stage> Stage { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Entity.Task> Task { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Team> Team { get; set; }
    }
}
