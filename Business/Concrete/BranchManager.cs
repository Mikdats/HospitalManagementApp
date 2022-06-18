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
    public class BranchManager : IBranchService
    {
        IBranchDal _branchDal;

        public BranchManager(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }

        public void Add(Branch branch)
        {
            _branchDal.Add(branch);
        }

        public void Delete(Branch branch)
        {
           _branchDal.Delete(branch);
        }

        public List<Branch> GetAll()
        {
           return _branchDal.GetAll();
        }

        public Branch GetById(int branchId)
        {
            return _branchDal.Get(u => u.BranchId == branchId);
        }

        public void Update(Branch branch)
        {
            _branchDal.Update(branch);
        }
    }
}
