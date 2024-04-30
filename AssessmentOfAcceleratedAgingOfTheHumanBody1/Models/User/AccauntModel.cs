using AssessmentOfAcceleratedAgingOfTheHumanBody1.Enums;

namespace AssessmentOfAcceleratedAgingOfTheHumanBody1.Models.User
{
    public class AccauntModel
    {
        public Guid? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? middleName { get; set; }
        public DateTime Birthday { get; set; }
        public Sex Sex { get; set; }
        public UserModel? User { get; set; }
        public UserModel? UserId { get; set; }
    }
}
