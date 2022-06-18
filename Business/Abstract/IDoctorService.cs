using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDoctorService
    {
        List<Doctor> GetAll();
        Doctor GetById(int doctorId);
        void Add(Doctor doctor);
        void Delete(Doctor doctor);
        void Update(Doctor doctor);
    }
}
