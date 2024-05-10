using models = AdressBook.Api.Models;
using AdressBook.Api.Services.Interface;
using System.Reflection;
using AdressBook.Api.Models;
using AdressBook.Api.Controllers.Models;

namespace AdressBook.Api.Services.Service
{
    public class AdressBookService : IAdressBook
    {
        private readonly IRepository<models.Concact> _repoService;
        public AdressBookService(IRepository<models.Concact> repository)
        {
            _repoService = repository;
        }

        public async Task DeleteContactAsync(string Id)
        {
            if(Id == null) throw new ArgumentNullException(nameof(Id));

            await _repoService.DeleteAsync(Id);
        }

        public async Task<Concact> GetConcactAsync(string ID)
        {
             return await _repoService.GetByID(ID);
        }

        public async Task<IEnumerable<models.Concact>> GetConcactsAsync()
        {
            return await _repoService.GetAll();
        }

        public async Task<ContactCreateResponse> InsertAsync(Concact concact)
        {
            await _repoService.Insert(concact);
            return new ContactCreateResponse { ObjID = concact.Id };
        }

        public async Task UpdateContactAsync(Concact concact)
        {
           
           if(concact == null) throw new ArgumentNullException(nameof(concact));

           await _repoService.UpdateAsync(concact);
        }
    }
}
