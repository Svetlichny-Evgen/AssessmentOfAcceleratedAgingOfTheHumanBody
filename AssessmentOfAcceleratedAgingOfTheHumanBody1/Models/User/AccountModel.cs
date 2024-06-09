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
        [Required, EmailAddress(ErrorMessage = "Будьласка, введіть адресу електронної пошти.")]
        public string? EMail { get; set; }
        [Required(ErrorMessage = "Будьласка, введіть ваш пароль."), MinLength(6, ErrorMessage = "Пароль повинен бути не менше 6 символів.")]
        public string? Password { get; set; }
    }
}
