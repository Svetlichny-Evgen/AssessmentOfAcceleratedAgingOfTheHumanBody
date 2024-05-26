using AssessmentOfAcceleratedAgingOfTheHumanBody1.Models.User;
using Microsoft.EntityFrameworkCore;
using System;

namespace AssessmentOfAcceleratedAgingOfTheHumanBody1.DAL.Data
{
    public class EntityDataBase : DbContext
    {
        public EntityDataBase(DbContextOptions<EntityDataBase> options)
            : base(options) { }
        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<ResultsModel> Results { get; set; }
    }
}
