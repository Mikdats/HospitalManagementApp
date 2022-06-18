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
    public class TaskModelManager : ITaskModelService
    {
        ITaskModelDal _taskModelDal;

        public TaskModelManager(ITaskModelDal taskModelDal)
        {
            _taskModelDal = taskModelDal;
        }

        public void Add(TaskModel taskModel)
        {
            _taskModelDal.Add(taskModel);
        }

        public void Delete(TaskModel taskModel)
        {
            _taskModelDal.Delete(taskModel);
        }

        public List<TaskModel> GetAll()
        {
            return _taskModelDal.GetAll();
        }

        public TaskModel GetById(int taskId)
        {
            return _taskModelDal.Get(u => u.TaskId == taskId);
        }

        public void Update(TaskModel taskModel)
        {
            _taskModelDal.Update(taskModel);
        }
    }
}
