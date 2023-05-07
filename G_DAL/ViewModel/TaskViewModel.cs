using G_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_DAL.ViewModel
{
    public class TaskViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PerformerMail { get; set; }
        public DateTime? End { get; set; }
    }
}
