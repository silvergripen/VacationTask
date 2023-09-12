using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VacationTaskUppgift.Models
{
    public class VacationStatusModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VacationStatusId { get; set; } = 0;
        public bool isActive { get; set; }

        [ForeignKey("VacationType")]
        public int FK_VacationTypeId { get; set; }
        public virtual VacationTypeModel VacationTypeModel { get; set; }

        [ForeignKey("TimeVacation")]
        public int FK_TimeVac {  get; set; }

        public virtual TimeVacationModel TimeVacation { get; set; }

        [ForeignKey("RequestVacation")]
        public int FK_RequestVacationId { get; set; }
        public virtual RequestVacationModel RequestVacation { get; set; }

        [ForeignKey("CurrentRequest")]
        public int FK_CurrentRequestId {  get; set; }

        public virtual CurrentRequestsModel CurrentRequests { get; set; }

    }
}
