namespace SommusPreVenda.Domain.Interfaces.Repositories
{
    public interface IDataContext
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void Finally();
    }
}
