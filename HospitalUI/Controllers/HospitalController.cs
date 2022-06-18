using Business.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HospitalUI.Controllers
{
    public class HospitalController : Controller
    {
        private readonly HospitalDbContext _context;
        private readonly IHospitalService _hospitalService;

        public HospitalController(HospitalDbContext context, IHospitalService hospitalManager)
        {
            _context = context;
            _hospitalService = hospitalManager;
        }

        public IActionResult Index()
        {
            return View();         
        }

        [HttpGet]
        public IActionResult Add()
        {
            //HospitalViewModel hospitalViewModel = new HospitalViewModel();
            //hospitalViewModel.hospitals = _hospitalService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Hospital hospital)
        {
            _hospitalService.Add(hospital);
            //HospitalViewModel hospitalViewModel = new HospitalViewModel();
            //hospitalViewModel.hospitals = _hospitalService.GetAll();
            return RedirectToAction("GetAll", "Hospital");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var hospital = _hospitalService.GetById(id);
            return View(hospital);
        }
        [HttpPost]
        public IActionResult Update(Hospital hospital)
        {
            _hospitalService.Update(hospital);
            return RedirectToAction("GetAll", "Hospital");
        }
        public IActionResult Delete(int id)
        {
            var hospital = _hospitalService.GetById(id);
            _hospitalService.Delete(hospital);
            return RedirectToAction("GetAll", "Hospital");
        }
        public IActionResult GetAll()
        {
            var result = _hospitalService.GetAll();
            return View(result);
        }
    }
}
