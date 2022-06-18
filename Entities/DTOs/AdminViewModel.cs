using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs
{
    public class AdminViewModel
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
        public string CommentName { get; set; }
        public string UserName { get; set; }
    }
}
