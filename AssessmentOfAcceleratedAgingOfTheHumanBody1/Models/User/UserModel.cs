using AssessmentOfAcceleratedAgingOfTheHumanBody1.Enums;

namespace AssessmentOfAcceleratedAgingOfTheHumanBody1.Models.User
{
    public class UserModel
    {
        public Guid? Id { get; set; }
        public Role? Role { get; set; }
        public AccauntModel? Accaunt { get; set; }
    }
}
