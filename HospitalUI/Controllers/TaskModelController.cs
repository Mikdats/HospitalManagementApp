using Business.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using MessagePack.Formatters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace HospitalUI.Controllers
{
    [Authorize(Roles = "Personnel")]
    public class TaskModelController : Controller
    {
        private readonly HospitalDbContext _hospitalDbContext;
        private readonly ITaskModelService _taskModelService;
        HospitalDbContext c = new HospitalDbContext();

        public TaskModelController(HospitalDbContext hospitalDbContext, ITaskModelService taskModelManager)
        {
            _hospitalDbContext = hospitalDbContext;
            _taskModelService = taskModelManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAll(string mail)
        {
            
            ViewBag.Mail = mail;
            List<PersonelViewModel> personelModels = (from t in _hospitalDbContext.TaskModels
                                                      join h in _hospitalDbContext.Hospitals
                                                      on t.HospitalId equals h.HospitalId
                                                      join p in _hospitalDbContext.Branchs
                                                      on t.BranchId equals p.BranchId
                                                      join d in _hospitalDbContext.Doctors
                                                      on t.DoctorId equals d.DoctorId
                                                      select new PersonelViewModel
                                                      {
                                                          TaskId = t.TaskId,
                                                          Task = t.Task,
                                                          TaskDate = t.TaskDate,
                                                          DoctorFullName = d.DoctorFullName,
                                                          HospitalName = h.HospitalName,
                                                          BranchName = p.BranchName,
                                                          Description = t.Description,
                                                          Mail = t.Email
                                                      }).Where(x => x.Mail == mail).ToList();
            return View(personelModels);
        }
        [HttpGet]
        public IActionResult Add(string mail)
        {

            ViewBag.Mail = mail;
            List<SelectListItem> AdminList = (from x in c.Hospitals.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.HospitalName,
                                                  Value = x.HospitalId.ToString()
                                              }).ToList();
            ViewBag.hospital = AdminList;

            List<SelectListItem> AdminList1 = (from x in c.Branchs.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.BranchName,
                                                   Value = x.BranchId.ToString()
                                               }).ToList();
            ViewBag.branch = AdminList1;

            List<SelectListItem> AdminList2 = (from x in c.Doctors.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.DoctorFullName,
                                                   Value = x.DoctorId.ToString()
                                               }).ToList();
            ViewBag.doktor = AdminList2;

            return View();
        }

        [HttpPost]
        public IActionResult Add(string mail, TaskModel taskModel)
        {
            mail = taskModel.Email;
            if (ModelState.IsValid)
            {
                _taskModelService.Add(taskModel);
                //return RedirectToAction("GetAll", "TaskModel");
                return RedirectToAction("GetAll","TaskModel", new { mail = mail });
            }
            return RedirectToAction("Add", taskModel);
    }

        [HttpGet]
        public IActionResult Update(int id,string username)
        {
            ViewBag.Mail = username;
            List<SelectListItem> AdminList = (from x in c.Hospitals.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.HospitalName,
                                                  Value = x.HospitalId.ToString()
                                              }).ToList();
            ViewBag.hospital = AdminList;

            List<SelectListItem> AdminList1 = (from x in c.Branchs.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.BranchName,
                                                   Value = x.BranchId.ToString()
                                               }).ToList();
            ViewBag.branch = AdminList1;

            List<SelectListItem> AdminList2 = (from x in c.Doctors.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.DoctorFullName,
                                                   Value = x.DoctorId.ToString()
                                               }).ToList();
            ViewBag.doktor = AdminList2;

            var result = _taskModelService.GetById(id);
            ViewBag.TaskDate = result.TaskDate.ToString("dd - MM - yyyy HH: mm");
            return View(result);
        }

        [HttpPost]
        public IActionResult Update(TaskModel taskModel)
        {
            _taskModelService.Update(taskModel);
            return RedirectToAction("GetAll", "TaskModel", new { mail = taskModel.Email });
        }
        public IActionResult Delete(int id)
        {
            var result = _taskModelService.GetById(id);
            _taskModelService.Delete(result);
            return RedirectToAction("GetAll", "TaskModel", new { mail = result.Email });
        }

    }
}
