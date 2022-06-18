using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Hospital:IEntity
    {
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
    }
}
