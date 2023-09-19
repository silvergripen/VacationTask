using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VacationTaskUppgift.Models
{
    public class CurrentRequestsModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CurrentVacId { get; set; }
        public bool IsAccepted { get; set; } = false;
        public bool IsRejected { get; set; } = true;

        [ForeignKey("RequestVacation")]

        public int FK_RequestVacationId { get; set; }

        public virtual ICollection<RequestVacationModel> RequestVacations { get; set;}

    }
}
