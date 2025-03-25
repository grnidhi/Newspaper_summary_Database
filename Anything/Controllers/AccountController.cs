using Anything.Data;
using Anything.Entities;
using Anything.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace Anything.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext appDbcontext)
        {
            _context = appDbcontext;
        }

        public IActionResult Index()
        {
            return View(_context.UserAccounts.ToList());
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!Enum.IsDefined(typeof(UserType), model.UserType))
                {
                    return View(model);
                }

                UserAccount account = new UserAccount
                {
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Username = model.Username,
                    Password = model.Password,
                    UserType = model.UserType
                };

                try
                {
                    _context.UserAccounts.Add(account);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Please enter a unique username or password");
                    return View(model);
                }
            }

            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.UserAccounts.FirstOrDefault(x => x.Username == model.Username && x.Password == model.Password);

                if (!Enum.IsDefined(typeof(UserType), model.UserType))
                {
                    ModelState.AddModelError("", "Invalid user type selected.");
                    return View(model);
                }

                if (user != null && user.UserType == model.UserType)
                {
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("Name", user.Firstname),
                new Claim(ClaimTypes.Role, user.UserType.ToString())
            };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity)).Wait();

                    // Redirect based on UserType
                    if (user.UserType == UserType.Planner)
                    {
                        return RedirectToAction("DisplayPlanner", "Account");
                    }
                    else
                    {
                        return RedirectToAction("SecurePage", "Account");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username, Password, or User Type.");
                }
            }
            return View(model);
        }

        public IActionResult DisplayPlanner()
        {
            // Your logic here
            ViewBag.Name = HttpContext.User.Identity.Name;
            return View();
        }


        [Authorize]
        public IActionResult SecurePage()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;
            return View();
        }

        
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
