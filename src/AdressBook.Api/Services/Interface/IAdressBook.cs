using AdressBook.Api.Controllers.Models;
using models = AdressBook.Api.Models;

namespace AdressBook.Api.Services.Interface
{
    public interface IAdressBook
    {
        Task<IEnumerable<models.Contact>> GetConcactsAsync();

        Task<models.Contact> GetConcactAsync(string ID);

        Task<ContactCreateResponse> InsertAsync(models.Contact concact);

        Task UpdateContactAsync(models.Contact concact);

        Task DeleteContactAsync(string Id);
    }
}
