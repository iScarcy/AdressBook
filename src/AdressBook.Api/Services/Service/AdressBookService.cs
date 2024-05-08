using models = AdressBook.Api.Models;
using AdressBook.Api.Services.Interface;
using System.Reflection;
using AdressBook.Api.Models;

namespace AdressBook.Api.Services.Service
{
    public class AdressBookService : IAdressBook
    {
        private readonly IRepository<models.Concact> _repoService;
        public AdressBookService(IRepository<models.Concact> repository)
        {
            _repoService = repository;
        }

        public async Task<Concact> GetConcactAsync(string ID)
        {
             return await _repoService.GetByID(ID);
        }

        public async Task<IEnumerable<models.Concact>> GetConcactsAsync()
        {
            return await _repoService.GetAll();
        }
    }
}
