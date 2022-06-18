using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetAll();
        Comment GetById(int commentId);
        void Add(Comment comment);
        void Delete(Comment comment);
        void Update(Comment comment);
        Comment GetByTaskId(int taskId);
    }
}
