using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScheduleProg.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScheduleProg.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace ScheduleProg.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context=context;
        }

        public IActionResult Index()
        {
            ViewData["Subgroup_Id"] = new SelectList(_context.Subgroups, "Id", "Subgr_Name");
            return RedirectToAction("Index", "Home");
        }

        //SD
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Email); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        /// <returns>

        ///Auth
        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
        {
        new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
        };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        ///
        [HttpGet]
        public IActionResult CreateStudent()
        {
            ViewData["Subgroup_Id"] = new SelectList(_context.Subgroups, "Id", "Subgr_Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudent model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { UserName= (model.First_Name+'_'+ model.Last_Name), First_Name=model.First_Name, Last_Name=model.Last_Name, Email= model.Email };
                // добавляем пользователя
                
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Студент");
                    Student student = new Student { First_Name = model.First_Name, Last_Name = model.Last_Name, Subgroup_Id = model.Subgroup_Id,User_Id= user.Id };
                    _context.Add(student);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index","Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult CreateTeacher()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeacher(CreateTeacher model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { UserName = (model.First_Name + '_' + model.Last_Name), First_Name = model.First_Name, Last_Name = model.Last_Name, Email = model.Email };
                // добавляем пользователя

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Вчитель");
                    Teacher teacher= new Teacher{ First_Name = model.First_Name, Last_Name = model.Last_Name, User_Id = user.Id };
                    _context.Add(teacher);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }




    }
}
