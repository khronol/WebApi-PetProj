using Microsoft.AspNetCore.Mvc;

namespace SkillProfi.Component
{
    public class LogoutViewViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
