using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_DAL.Entity
{
    public class Task
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public User Creator { get; set; }
        public User Performer { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
}
