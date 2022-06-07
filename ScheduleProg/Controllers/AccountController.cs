using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScheduleProg.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScheduleProg.Data;
using Microsoft.AspNetCore.Authentication;

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
            return View();
        }


       /* [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильний логiн або пароль");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
*/

        /// <returns>


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
