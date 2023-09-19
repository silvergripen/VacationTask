using Microsoft.EntityFrameworkCore;
using VacationTaskUppgift.Models;

namespace VacationTaskUppgift.Data
{
    public class VacationDbContext : DbContext
    {
        public VacationDbContext(DbContextOptions<VacationDbContext> options) : base(options) 
        {
            
        }
        
        public DbSet<CurrentRequestsModel> CurrentRequests { get; set; }
        public DbSet<PersonelModel> Personels { get; set;}
        public DbSet<RequestVacationModel> RequestVacations { get; set; }
        public DbSet<VacationStatusModel> VacationStatuses { get; set; }
        public DbSet<VacationTypeModel> VacationTypes { get; set; }

    }
}
