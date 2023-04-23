﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_DAL.Entity
{
    public class User : BaseEntity
    {
        public string? Email { get; set; }  
        public string Password { get; set; }
        public string UserName { get; set; }
        public List<Role>? Role { get; set; }
        public List<Team>? Team { get; set; }
    }
}