using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_DAL.Entity
{
    public class Task : BaseEntity
    {
        public User Creator { get; set; }
        public User Performer { get; set; }
        public DateTime? End { get; set; }
    }
}
