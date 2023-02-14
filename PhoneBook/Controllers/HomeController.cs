using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.BLL.Abstracts;
using PhoneBook.CORE.Entities.Concretes;
using PhoneBook.Models; 
using System.Diagnostics;

namespace PhoneBook.Controllers
{
    public class HomeController : Controller
    { 
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IBookService _bookService;
        private readonly IPhoneInfoService _phoneInfoService; 
        public HomeController(IPhoneInfoService phoneInfoService,IBookService bookService,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _phoneInfoService = phoneInfoService;
            _bookService = bookService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View();
            }
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
    }
}