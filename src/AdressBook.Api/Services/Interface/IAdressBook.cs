using models = AdressBook.Api.Models;

namespace AdressBook.Api.Services.Interface
{
    public interface IAdressBook
    {
        Task<IEnumerable<models.Concact>> GetConcactsAsync();

         Task<models.Concact> GetConcactAsync(string ID);
    }
}
