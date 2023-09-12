using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VacationTaskUppgift.Models
{
    public class VacationTypeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeId { get; set; } = 0;

        [MaxLength(50)]
        public string TypeName { get; set; }
        public int timeLeft { get; set; }
        public int maxTime { get; set; }
    }
}
