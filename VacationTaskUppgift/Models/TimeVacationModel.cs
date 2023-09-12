using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VacationTaskUppgift.Models
{
    public class TimeVacationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VacationTimeId { get; set; } = 0;
        public DateTime CurrentDate { get; set; }

        [ForeignKey("Personel")]
        public int FK_Personnel { get; set; }
        public virtual PersonelModel Personel { get; set; }

        [ForeignKey("VacationSatuse")]
        public int FK_VacStatus { get; set; }
        public virtual VacationStatusModel VacationStatus { get; set; }
    }
}
