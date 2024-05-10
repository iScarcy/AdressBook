using AdressBook.Api.Controllers.Models;
using models = AdressBook.Api.Models;

namespace AdressBook.Api.Services.Interface
{
    public interface IAdressBook
    {
        Task<IEnumerable<models.Concact>> GetConcactsAsync();

        Task<models.Concact> GetConcactAsync(string ID);

        Task<ContactCreateResponse> InsertAsync(models.Concact concact);

        Task UpdateContactAsync(models.Concact concact);

        Task DeleteContactAsync(string Id);
    }
}
