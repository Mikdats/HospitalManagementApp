using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBranchService
    {
        List<Branch> GetAll();
        Branch GetById(int branchId);
        void Add(Branch branch);
        void Delete(Branch branch);
        void Update(Branch branch);
    }
}
