using Business.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HospitalUI.Controllers
{
    public class BranchController : Controller
    {
        private readonly HospitalDbContext _context;
        private readonly IBranchService _branchService;

        public BranchController(HospitalDbContext context, IBranchService branchService)
        {
            _context = context;
            _branchService = branchService;
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
        public IActionResult Add(Branch branch)
        {
            _branchService.Add(branch);
            return RedirectToAction("GetAll", "Branch");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var branch = _branchService.GetById(id);
            return View(branch);
        }
        [HttpPost]
        public IActionResult Update(Branch branch)
        {
            _branchService.Update(branch);
            return RedirectToAction("GetAll", "Branch");
        }
        public IActionResult Delete(int id)
        {
            var branch = _branchService.GetById(id);
            _branchService.Delete(branch);
            return RedirectToAction("GetAll", "Branch");
        }
        public IActionResult GetAll()
        {
            var result = _branchService.GetAll();
            return View(result);
        }
    }
}
