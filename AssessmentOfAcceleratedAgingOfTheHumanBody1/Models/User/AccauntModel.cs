using AssessmentOfAcceleratedAgingOfTheHumanBody1.Enums;

namespace AssessmentOfAcceleratedAgingOfTheHumanBody1.Models.User
{
    public class AccauntModel
    {
        public Guid? Id { get; set; }
        public string? FullName { get; set; }
        public DateTime Birthday { get; set; }
        public Sex Sex { get; set; }
        public string? EMail { get; set; }
        public string? Password { get; set; }
        public UserModel? User { get; set; }
        public UserModel? UserId { get; set; }
    }
}
