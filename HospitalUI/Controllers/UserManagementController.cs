using Business.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserManagementController : Controller
    {
        private readonly HospitalDbContext _hospitalDbContext;
        private readonly IUserService _userService;
        private readonly ICommentService _commentService;
        HospitalDbContext c = new HospitalDbContext();

        public UserManagementController(HospitalDbContext hospitalDbContext, IUserService userService, ICommentService commentService)
        {
            _hospitalDbContext = hospitalDbContext;
            _userService = userService;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            //var result = from user in _hospitalDbContext.Users
            //             from role in _hospitalDbContext.Roles.Where(r => r.RoleId == user.RoleId).ToList()
            //             select new User()
            //             {
            //                 UserId = user.UserId,
            //                 RoleId = role.RoleId,
            //                 Email = user.Email,
            //                 FirstName = user.FirstName,
            //                 LastName = user.LastName,
            //                 Password = user.Password,
            //                 PasswordRepeat = user.PasswordRepeat,                         
            //                 Role = (role == null) ? null : new Role()
            //                 {
            //                     RoleId = role.RoleId,
            //                     RoleName = role.RoleName
            //                 }
            //             };
            //return View(result.ToList());
            return View();
        }

        [HttpGet]
        public IActionResult GetAll(User user)
        {
            var result = _userService.GetAll();
            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            _userService.Add(user);
            return RedirectToAction("GetAll", "UserManagement");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var user = _userService.GetById(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult Update(User user)
        {
            _userService.Update(user);
            return RedirectToAction("GetAll", "UserManagement");
        }
        public IActionResult Delete(int id)
        {
            var user = _userService.GetById(id);
            _userService.Delete(user);
            return RedirectToAction("GetAll", "UserManagement");
        }
        [HttpGet]
        public IActionResult GetAllTaskForAdmin()
        {
            List<AdminViewModel> adminViewModel = (from t in _hospitalDbContext.TaskModels
                                                   join h in _hospitalDbContext.Hospitals
                                                   on t.HospitalId equals h.HospitalId
                                                   join p in _hospitalDbContext.Branchs
                                                   on t.BranchId equals p.BranchId
                                                   join d in _hospitalDbContext.Doctors
                                                   on t.DoctorId equals d.DoctorId
                                                   join u in _hospitalDbContext.Users
                                                   on t.Email equals u.Email
                                                   join c in _hospitalDbContext.Comments
                                                   on t.TaskId equals c.TaskId
                                                   into gj
                                                   from x in gj.DefaultIfEmpty()
                                                   select new AdminViewModel
                                                   {
                                                       
                                                       TaskId = t.TaskId,
                                                       Task = t.Task,
                                                       TaskDate = t.TaskDate,
                                                       DoctorFullName = d.DoctorFullName,
                                                       HospitalName = h.HospitalName,
                                                       BranchName = p.BranchName,
                                                       Description = t.Description,
                                                       CommentName= (x == null ? String.Empty : x.CommentName),
                                                       UserName = String.Format("{0} {1}", u.FirstName, u.LastName)
                                                   }).ToList();
            return View(adminViewModel);

        }

        [HttpGet]
        public IActionResult GetTaskForAdminComment(int id)
        {

            AdminViewModel adminViewModel = (from t in _hospitalDbContext.TaskModels
                                                   join h in _hospitalDbContext.Hospitals
                                                   on t.HospitalId equals h.HospitalId
                                                   join p in _hospitalDbContext.Branchs
                                                   on t.BranchId equals p.BranchId
                                                   join d in _hospitalDbContext.Doctors
                                                   on t.DoctorId equals d.DoctorId
                                                   join c in _hospitalDbContext.Comments
                                                   on t.TaskId equals c.TaskId
                                                   into gj
                                                   from x in gj.DefaultIfEmpty()
                                                   where t.TaskId == id
                                                   select new AdminViewModel
                                                   {
                                                       TaskId = t.TaskId,
                                                       Task = t.Task,
                                                       TaskDate = t.TaskDate,
                                                       DoctorFullName = d.DoctorFullName,
                                                       HospitalName = h.HospitalName,
                                                       BranchName = p.BranchName,
                                                       Description = t.Description,
                                                       
                                                       CommentName = (x == null ? String.Empty : x.CommentName)
                                                   }).SingleOrDefault();
            return View(adminViewModel);        

        }
        [HttpPost]
        public IActionResult GetTaskForAdminComment(AdminViewModel adminViewModel)
        {
            var result =_commentService.GetByTaskId(adminViewModel.TaskId);
            if (result == null)
            {
                Comment comment=new Comment { TaskId = adminViewModel.TaskId,CommentName=adminViewModel.CommentName };
                _commentService.Add(comment);
            }
            else
            {
                result.CommentName = adminViewModel.CommentName;
                _commentService.Update(result);
            }
            return RedirectToAction("GetAllTaskForAdmin", "UserManagement");
            
        }
       
    }
}