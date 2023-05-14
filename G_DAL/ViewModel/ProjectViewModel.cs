using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_DAL.ViewModel
{
    public class ProjectViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Stage { get; set; }
        public string StageDescription { get; set; }
        public string StatusDescription { get; set; }
        public string Status { get; set; }
        public string Color { get; set; }
    }
}
