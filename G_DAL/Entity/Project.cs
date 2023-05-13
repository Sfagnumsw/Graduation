using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_DAL.Entity
{
    public class Project : BaseEntity
    {
        public int? TeamId { get; set; }
        public int? StageId { get; set; }
    }
}
