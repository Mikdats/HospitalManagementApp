using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Doctor:IEntity
    {
        [Key]
        public int DoctorId { get; set; }
        [Required]
        public string DoctorFullName { get; set; }
        

    }
}
