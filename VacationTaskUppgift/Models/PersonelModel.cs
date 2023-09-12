using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationTaskUppgift.Models
{
    public partial class PersonelModel : IdentityUser
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int personelId { get; set; } = 0;
        [MaxLength(50)]
        [Required]
        [DisplayName("Hela namnet")]
        public string FullName { get; set; } = null!;
        [MaxLength(50)]
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = null!;

        [ForeignKey("TimeVacation")]
        public int Fk_TimeVacationId { get; set; }
        public virtual TimeVacationModel TimeVacation { get; set; }
        public string IsAdmin { get; set; }
    }
}
