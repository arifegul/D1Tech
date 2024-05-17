using D1Tech.User.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D1Tech.User.Domain.Entities
{
    public class Users : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
