using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_DAL.Entity
{
    public class Project : BaseEntity
    {
        public Team? Team { get; set; }
        public Stage Stage { get; set; }
    }
}
