 using AssessmentOfAcceleratedAgingOfTheHumanBody1.DAL.Data;
using AssessmentOfAcceleratedAgingOfTheHumanBody1.DAL.Interfaces;
using AssessmentOfAcceleratedAgingOfTheHumanBody1.Models.User;
using Microsoft.EntityFrameworkCore;

namespace AssessmentOfAcceleratedAgingOfTheHumanBody1.DAL.Repositories
{
    public class ResultsRepository : IResultsRepository
    {
        private readonly EntityDataBase _database;

        public ResultsRepository(EntityDataBase database)
        {
            _database = database;
        }

        public ResultsModel Create(ResultsModel model)
        {
            var entry = _database.Results.Add(model);
            _database.SaveChanges();
            return entry.Entity;
        }

        public bool Delete(ResultsModel model)
        {
            var entity = _database.Results.First(u => u.Id == model.Id);
            var entry = _database.Results.Remove(entity);
            _database.SaveChanges();
            return true;
        }

        public ResultsModel Read(Guid id)
        {
            return _database.Results.First(u => u.Id == id);
        }

        public List<ResultsModel> Select()
        {
            return _database.Results.ToList();
        }

        public ResultsModel Update(ResultsModel model)
        {
            var entry = _database.Results.Update(model);
            _database.SaveChanges();
            return entry.Entity;
        }
    }
}
