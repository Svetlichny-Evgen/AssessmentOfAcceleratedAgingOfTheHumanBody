using AssessmentOfAcceleratedAgingOfTheHumanBody1.Models.User;

namespace AssessmentOfAcceleratedAgingOfTheHumanBody1.DAL.Interfaces
{
    public interface IUserAccountService
    {
        AccountModel Register(AccountModel model);
        AccountModel Login(string email, string password);
        AccountModel Update(AccountModel model);
        bool Delete(Guid id);
    }
}
