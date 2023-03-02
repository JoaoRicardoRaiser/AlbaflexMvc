namespace AlbaflexMvc.Data.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
