using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class HospitalViewModel
    {
        public Hospital hospital { get; set; }
        public List<Hospital> hospitals { get; set; }
        

    }
}
