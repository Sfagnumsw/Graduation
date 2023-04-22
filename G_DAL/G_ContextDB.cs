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
        DbSet<Project> Project { get; set; }
        DbSet<Role> Role { get; set; }
        DbSet<Stage> Stage { get; set; }
        DbSet<Status> Status { get; set; }
        DbSet<Entity.Task> Task { get; set; }
        DbSet<User> User { get; set; }
        DbSet<Team> Team { get; set; }
    }
}
