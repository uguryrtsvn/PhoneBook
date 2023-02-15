using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.BLL.Abstracts;
using PhoneBook.CORE.Entities.Concretes;
using PhoneBook.Models; 
using System.Diagnostics;
using System.Security.Claims;
using System.Text;
#nullable disable
namespace PhoneBook.Controllers
{
    public class HomeController : Controller
    { 
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IBookService _bookService;
        private readonly IPhoneInfoService _phoneInfoService;
        private readonly INotyfService _notifyService;
        public HomeController(INotyfService notifyService,IPhoneInfoService phoneInfoService,IBookService bookService,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _notifyService = notifyService;
            _phoneInfoService = phoneInfoService;
            _bookService = bookService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                string userId = _userManager.GetUserId(HttpContext.User); 
                return View(await _bookService.GetByUserIdAsync(userId));
            }
            _notifyService.Warning("Lütfen önce giriş yapın.");
            return RedirectToAction("Login");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            { 
                _notifyService.Error(ModelState.Values.First().Errors.Last().ErrorMessage);
                return View(model);
            }

            AppUser user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                _notifyService.Error("Geçersiz e-mail adresi !");
                return View(model);
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (!result.Succeeded)
            {
                _notifyService.Error("Geçersiz kullanıcı adı veya şifre !"); 
                return View(model);
            }

            _notifyService.Success($"Hoşgeldin : {user.UserName}");
            return RedirectToAction(controllerName: "Home", actionName: "Index");
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            { 
                AppUser user = new AppUser()
                {
                    UserName = model.FirstName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Adress = model.Adress,
                    PhoneNumber = model.PhoneNumber, 
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
          
                if (result.Succeeded)
                {
                    Book b = new Book()
                    {
                        CreatorUser = user,
                        CreatorUserId = user.Id,
                    };
                    var book = await _bookService.CreateAsync(b);
                    _notifyService.Success("Kullanıcı kaydı başarılı. Giriş yapabilirsiniz.");
                    return RedirectToAction("Login");
                }
                else
                {
                    LogResultErrors(result);
                    StringBuilder msg = new();
                    foreach (IdentityError item in result.Errors)
                    {
                        msg.Append($"<p>{item.Description}</p>");
                    }
                    _notifyService.Error(msg.ToString());
                    return View(model);
                }
            }

            var modelStateErrors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            StringBuilder errorMsg = new();
            foreach (string item in modelStateErrors)
            {
                errorMsg.Append($"<p>{item}</p>");
            }
            _notifyService.Error(errorMsg.ToString());
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        { 
            await _signInManager.SignOutAsync();
            return View("Login");
        }

        private void LogResultErrors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", $"{error.Description}");
            }
        }


        public async Task<IActionResult> CreatePhoneInfo(PhoneInfo phoneInfo)
        { 
            var a = await _phoneInfoService.CreateAsync(phoneInfo); 
            return PartialView("~/Views/Shared/_BookPartial.cshtml",await _bookService.GetByIdAsync(phoneInfo.BookId));
        }

    }
}