using Microsoft.AspNetCore.Mvc;

namespace VacationTaskUppgift.Controllers
{
    public class PersonelHomepage : Controller
    {
        //Should show everything about applications and current vacations.
        public IActionResult Index()
        {
            return View();
        }
    }
}
