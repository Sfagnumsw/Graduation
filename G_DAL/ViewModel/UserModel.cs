using G_DAL.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_DAL.ViewModel
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
    }
}
