using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VacationTaskUppgift.Models
{
    public class CurrentRequestsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CurrentVacId { get; set; } = 0;
        public bool IsAccepted { get; set; }
        public bool IsRejected { get; set; }

        [ForeignKey("VacationType")]
        public int FK_VacTypeId { get; set; }
        public virtual VacationTypeModel VacationType { get; set; }

    }
}
