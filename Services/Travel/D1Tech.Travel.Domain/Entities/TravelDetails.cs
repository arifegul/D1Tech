using D1Tech.Travel.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D1Tech.Travel.Domain.Entities
{
    public class TravelDetails : BaseEntity
    {
        public int TravelsId { get; set; }
        public string Address { get; set; }
        public Travels Travels { get; set; }
    }
}
