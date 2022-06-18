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
    public class HospitalManager : IHospitalService
    {
        IHospitalDal _hospitalDal;

        public HospitalManager(IHospitalDal hospitalDal)
        {
            _hospitalDal = hospitalDal;
        }

        public void Add(Hospital hospital)
        {
           _hospitalDal.Add(hospital);
        }

        public void Delete(Hospital hospital)
        {
            _hospitalDal.Delete(hospital);  
        }

        public List<Hospital> GetAll()
        {
            return _hospitalDal.GetAll();
        }

        public Hospital GetById(int hospitalId)
        {
            return _hospitalDal.Get(u => u.HospitalId == hospitalId);
        }

        public void Update(Hospital hospital)
        {
            _hospitalDal.Update(hospital);
        }
    }
}
