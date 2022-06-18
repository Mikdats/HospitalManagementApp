using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HospitalUI.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly HospitalDbContext _hospitalDbContext;

        public UserController(HospitalDbContext hospitalDbContext)
        {
            _hospitalDbContext = hospitalDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index([Bind("Email", "Password")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                ClaimsIdentity identity = null;
                bool isAuthenticated = false;
                User user = await _hospitalDbContext.Users.Include(k => k.Role).FirstOrDefaultAsync(m => m.Email == userViewModel.Email && m.Password == userViewModel.Password);
                if (user == null)
                {
                    ModelState.AddModelError("Error1", "Kullanıcı bulunamadı.");
                    return View();
                }

                identity = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Sid,user.UserId.ToString()),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.Role,user.Role.RoleName),
                    }, CookieAuthenticationDefaults.AuthenticationScheme
                    );
                isAuthenticated = true;
                if (isAuthenticated)
                {
                    var claim = new ClaimsPrincipal(identity);
                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claim,

                        new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTime.Now.AddMinutes(60)
                        });
                    var data = userViewModel.Email.ToString();
                    TempData["Email"] = data;
                
                    if (user.Role.RoleName == "Admin")
                    {
                        return Redirect("~/UserManagement/Index");
                    }
                    else if (user.Role.RoleName == "Personnel")
                    {
                        //return Redirect("~/TaskModel/GetAll");
                        return RedirectToAction("GetAll", "TaskModel", new { mail=data });
                    }
                    else
                    {
                        return Redirect("~/Home/ErrorPage");
                    }
                }

            }
            return View(userViewModel);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _hospitalDbContext.Users.Add(user);
                user.RoleId = 2;
                _hospitalDbContext.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = user.FirstName + " " + user.LastName + " " + "başarılı şekilde kayıt oldu.";
            }
            return View();
        }

    }
}
