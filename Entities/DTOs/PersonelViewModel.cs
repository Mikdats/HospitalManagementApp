using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PersonelViewModel
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        public string Task { get; set; }

        [Required]
        public DateTime TaskDate { get; set; }
        public string HospitalName { get; set; }
        public string BranchName { get; set; }
        public string DoctorFullName { get; set; }

        [Required]
        public string Description { get; set; }
        public string Mail { get; set; }
    }
}
