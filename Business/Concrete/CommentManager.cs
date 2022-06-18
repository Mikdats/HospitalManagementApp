using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void Add(Comment comment)
        {
            _commentDal.Add(comment);
        }

        public void Delete(Comment comment)
        {
            _commentDal.Delete(comment);    
        }

        public List<Comment> GetAll()
        {
           return _commentDal.GetAll();
        }

        public Comment GetById(int commentId)
        {
            return _commentDal.Get(u => u.CommentId == commentId);
        }

        public Comment GetByTaskId(int taskId)
        {
            return _commentDal.Get(u => u.TaskId == taskId);
        }

        public void Update(Comment comment)
        {
            _commentDal.Update(comment);
        }
    }
}
