using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class TaskModel:IEntity
    {
        [Key]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Task alanı gereklidir.")]
        public string Task { get; set; }

        [Required(ErrorMessage = "Tarih/Saat alanı gereklidir.")]
        public DateTime TaskDate { get; set; }
        public int HospitalId { get; set; }
        //public string HospitalName { get; set; }
        public int BranchId { get; set; }
        //public string BranchName { get; set; }
        public int DoctorId { get; set; }
        //public string DoctorFullName { get; set; }

        [Required(ErrorMessage ="Ne Yapıldı alanı gereklidir.")]
        public string Description { get; set; }
        public string Email { get; set; }

    }
}
