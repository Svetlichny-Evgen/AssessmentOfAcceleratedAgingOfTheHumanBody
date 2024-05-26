using AssessmentOfAcceleratedAgingOfTheHumanBody1.Enums;
using System.ComponentModel.DataAnnotations;

namespace AssessmentOfAcceleratedAgingOfTheHumanBody1.Models.User
{
    public class AccountModel
    {
        public Guid? Id { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public Sex Sex { get; set; }
        [Required, EmailAddress]
        public string? EMail { get; set; }
        [Required, MinLength(6)]
        public string? Password { get; set; }
    }
}
