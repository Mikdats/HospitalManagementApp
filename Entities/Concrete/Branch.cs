using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Branch:IEntity
    {
        [Key]
        public int BranchId { get; set; }
        [Required]
        public string BranchName { get; set; }
    }
}
