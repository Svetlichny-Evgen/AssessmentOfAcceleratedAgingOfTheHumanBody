using AssessmentOfAcceleratedAgingOfTheHumanBody1.DAL.Data;
using AssessmentOfAcceleratedAgingOfTheHumanBody1.DAL.Interfaces;
using AssessmentOfAcceleratedAgingOfTheHumanBody1.Models.User;
using Microsoft.EntityFrameworkCore;

namespace AssessmentOfAcceleratedAgingOfTheHumanBody1.DAL.Repositories
{
    public class AccauntRepository : IAccauntRepository
    {
        private readonly EntityDataBase _database;

        public AccauntRepository(EntityDataBase database)
        {
            _database = database;
        }

        public AccountModel Create(AccountModel model)
        {
            var entry = _database.Accounts.Add(model);
            _database.SaveChanges();
            return entry.Entity;
        }

        public bool Delete(AccountModel model)
        {
            var entity = _database.Accounts.First(u => u.Id == model.Id);
            var entry = _database.Accounts.Remove(entity);
            _database.SaveChanges();
            return true;
        }

        public AccountModel Read(Guid id)
        {
            return _database.Accounts.First(u => u.Id == id);
        }

        public List<AccountModel> Select()
        {
            return _database.Accounts.ToList();
        }

        public AccountModel Update(AccountModel model)
        {
            var entry = _database.Accounts.Update(model);
            _database.SaveChanges();
            return entry.Entity;
        }
    }
}
