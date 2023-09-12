using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VacationTaskUppgift.Models
{
    public class RequestVacationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestVacId { get; set; } = 0;

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }
        [ForeignKey("VacationType")]
        public int FK_VacationType { get; set; }
        public virtual VacationTypeModel VacationType { get; set; }

        [ForeignKey("Personel")]
        public int FK_Personel {  get; set; }

        public virtual PersonelModel Personel { get; set;}



    }
}
