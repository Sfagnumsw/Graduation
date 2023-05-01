using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_DAL.Entity
{
    public class Team : BaseEntity
    {
       public List<User> Users = new List<User>();
    }
}
