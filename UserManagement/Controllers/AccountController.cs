using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace UserManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<user> _signInManager;
        private readonly UserManager<user> _userManager;
        private readonly ApplicationDbContext _db;

        public AccountController(
        SignInManager<user> signInManager,
        UserManager<user> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
           
        }

        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }

        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public  ActionResult Signup(user u)
        {
            if (ModelState.IsValid)
            {

                _db.user.Add(u);
                if (_db.SaveChanges() > 0)
                { 
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(user model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(
                        user.Email, model.password, model.RememberMe, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        // Successfully logged in, redirect to the returnUrl or a default page
                        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }
    }
}
