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
            if (search != null)
            {
                var getPersonel = await context.Personels
                    .Where(p => p.Email.ToLower().Contains(search) ||
                    p.FullName.ToLower().Contains(search) ||
                    search == p.FullName.Trim()
                ).ToListAsync();
                return View("GetPersonel", getPersonel);
            }
            else { return View(); }
        }
        public async Task<IActionResult> GetVacations(string search = "")
        {
            var statuses = context.VacationStatuses.ToListAsync();
            var requests = context.RequestVacations.ToListAsync();
            var time = context.TimeVacations.ToListAsync();
            var types = context.VacationTypes.ToListAsync();
            var person = context.Personels.ToListAsync();
            var allVacations = (from vs in context.VacationStatuses
                                join rv in context.RequestVacations on vs.FK_RequestVacationId equals rv.RequestVacId
                                join cr in context.CurrentRequests on vs.FK_CurrentRequestId equals cr.CurrentVacId
                                join tv in context.TimeVacations on vs.FK_TimeVac equals tv.VacationTimeId
                                join ty in context.VacationTypes on vs.FK_VacationTypeId equals ty.TypeId
                                join pe in context.Personels on rv.FK_Personel equals pe.personelId
                                where ty.TypeName.Contains(search) || pe.FullName.Contains(search)
                                select new
                                {
                                    status = vs.isActive,
                                    start = rv.DateStart,
                                    end = rv.DateEnd,
                                    type = ty.TypeName,
                                    person = pe.FullName,
                                    email = pe.Email
                                    
                                }).ToListAsync();
            return View(allVacations);
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