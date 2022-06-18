using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Role : IEntity
    {
        [Key]
        public byte RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
