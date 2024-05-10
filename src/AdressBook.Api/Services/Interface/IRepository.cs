namespace AdressBook.Api.Services.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetByID(string ID);

        Task<T> Insert(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(string ID);
    }
}
