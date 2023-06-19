using Microsoft.AspNetCore.Mvc;
using SkillProfi.Data;
using SkillProfi.Interfaces;
using SkillProfi.Models;

namespace SkillProfi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppealsData _data;
        public HomeController(IAppealsData data)
        {
            _data = data;
        }

        #region Main pages
        public IActionResult Index()
        {
            return View();
        }
        [Route("/Projects")]
        public IActionResult Projects()
        {
            return View();
        }
        [Route("/Services")]
        public IActionResult Services()
        {
            return View();
        }
        [Route("/Blog")]
        public IActionResult Blog()
        {
            return View();
        }
        [Route("/Contacts")]
        public IActionResult Contacts()
        {
            return View();
        }
        #endregion

        #region Project pages
        [Route("/Meat")]
        public IActionResult Meat()
        {
            return View();
        }
        [Route("/Read")]
        public IActionResult Read()
        {
            return View();
        }
        [Route("/Sberbank")]
        public IActionResult Sberbank()
        {
            return View();
        }
        #endregion

        #region Blog Pages
        [Route("/First")]
        public IActionResult First()
        {
            return View();
        }
        [Route("/Second")]
        public IActionResult Second()
        {
            return View();
        }
        [Route("/Third")]
        public IActionResult Third()
        {
            return View();
        }
        [Route("/Fourth")]
        public IActionResult Fourth()
        {
            return View();
        }
        #endregion

        public IActionResult AddAppeal(string name,string email, string appeal)
        {
            Appeal temp = new Appeal()
            {
                
                Name = name,
                Email = email,
                userAppeal = appeal
            };
            _data.addAppeal(temp);
            return Redirect("~/");
        }
    }
}
