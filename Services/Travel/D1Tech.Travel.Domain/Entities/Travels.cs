using D1Tech.Travel.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D1Tech.Travel.Domain.Entities
{
    public class Travels : BaseEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}
