using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VacationTaskUppgift.Data;
using VacationTaskUppgift.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace VacationTaskUppgift.Controllers
{
    public class VacationApplicationController : Controller
    {
        private readonly VacationDbContext context;
        public VacationApplicationController(VacationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var vacationList = await context.RequestVacations
                 .Include(e => e.VacationType)
                 .Include(l => l.Personel)
                 .AsNoTracking().ToListAsync();
            return View(vacationList);
        }
        public async Task<IActionResult> Create()
        {
            //What to select from list.
            var equerys = from e in context.VacationTypes
                          select e.TypeName;
            ViewBag.EDropDown = new SelectList(context.VacationTypes, "TypeId", "TypeName");
            var lquerys = from l in context.Personels
                          select l.FullName;
            //Should be currently logged in person
            ViewBag.EDropDown = new SelectList(context.Personels, "PersonelId", "FName");           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(VacationApplicationController viewModel)
        {
            if (viewModel == null)
            {
                return BadRequest();
            }
            return RedirectToAction("Index"); //This might be wrong.
        }

    }
}
