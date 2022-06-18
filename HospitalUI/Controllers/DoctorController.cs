using Business.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HospitalUI.Controllers
{
    public class DoctorController : Controller
    {
        private readonly HospitalDbContext _context;
        private readonly IDoctorService _doctorService;

        public DoctorController(HospitalDbContext context, IDoctorService doctorService)
        {
            _context = context;
            _doctorService = doctorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Doctor doctor)
        {
            _doctorService.Add(doctor);
            return RedirectToAction("GetAll", "Doctor");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var branch = _doctorService.GetById(id);
            return View(branch);
        }
        [HttpPost]
        public IActionResult Update(Doctor doctor)
        {
            _doctorService.Update(doctor);
            return RedirectToAction("GetAll", "Doctor");
        }
        public IActionResult Delete(int id)
        {
            var doctor = _doctorService.GetById(id);
            _doctorService.Delete(doctor);
            return RedirectToAction("GetAll", "Doctor");
        }
        public IActionResult GetAll()
        {
            var result = _doctorService.GetAll();
            return View(result);
        }
    }
}
