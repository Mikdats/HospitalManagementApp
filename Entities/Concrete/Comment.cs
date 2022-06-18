using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment:IEntity
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string CommentName { get; set; }
        [Required]
        public int TaskId { get; set; }
    }
}
