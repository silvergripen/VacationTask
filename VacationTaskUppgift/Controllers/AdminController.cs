using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacationTaskUppgift.Data;
using VacationTaskUppgift.Models;

namespace VacationTaskUppgift.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<PersonelModel> userManager;
        private readonly VacationDbContext context;
        public AdminController(VacationDbContext context, UserManager<PersonelModel> userManager)
        {
            this.context = context;
            this.userManager = userManager;
 
        }
            public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetPersonel(string search = "")
        {
            string úserId = userManager.GetUserId(User);
            search = search.Trim();
            search = search.ToLower();
            if (search == "")
            {
                var getPersonel = await context.Personels
                    .Include(p => p.Email)
                    .Include(d => d.FullName)
                    .ToListAsync();
                return View("SearchPersonel", getPersonel);
            }
            else 
            {
                var getPersonel = await context.Personels
                    .Include(p => p.Email)
                    .Include(o => o.FullName)
                    .Where(d => d.Email.ToLower().Contains(search) ||
                     d.FullName.ToLower().Contains(search)
                     ).ToListAsync();
                return View("SearchPersonel", getPersonel);
            }
        }
        public async Task<IActionResult> GetVacations(string search = "")
        {
            var getVacation = await context.VacationStatuses
                .Include(p => p.Personel)
                .Include(f => f.CurrentRequest)
                 .ThenInclude(cr => cr.RequestVacations)
                    .ThenInclude(rv => rv.VacationType)
                
                .Where(r => r.Personel.FullName.ToLower().Contains(search) ||
                 r.Personel.Email.ToLower().Contains(search)
                 )
                .ToListAsync();
           
            return View("SearchVacation", getVacation);
        }
        public async Task<IActionResult> EditVacations()
        {
            return View();
        }
    }
}
//if (search == "")
//{
//    //var vacationList = await context.VacationStatuses
//    //     .Where(p => p.).ToLower.Contains(search) ||
//    //     .where
//}