using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITaskModelService
    {
        List<TaskModel> GetAll();
        TaskModel GetById(int taskId);
        void Add(TaskModel taskModel);
        void Delete(TaskModel taskModel);
        void Update(TaskModel taskModel);
    }
}
