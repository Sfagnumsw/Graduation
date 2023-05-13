using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_DAL.Entity
{
    public class Task : BaseEntity
    {
        public string CreatorMail { get; set; }
        public string PerformerMail { get; set; }
        public DateTime? End { get; set; }
    }
}
