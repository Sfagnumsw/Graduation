using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_DAL.Entity
{
    public class Stage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Status State { get; set; }
    }
}
