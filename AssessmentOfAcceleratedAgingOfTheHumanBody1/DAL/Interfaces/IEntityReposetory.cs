namespace AssessmentOfAcceleratedAgingOfTheHumanBody1.DAL.Interfaces
{
    public interface IEntityReposetory<T>
    {
        T Create(T model);
        T Update(T model);
        T Read(Guid id);
        bool Delete(T model);
        List<T> Select();
    }
}
