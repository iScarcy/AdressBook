using AdressBook.Api.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using models = AdressBook.Api.Models;

namespace AdressBook.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdressBookController : Controller
    {
        private readonly IAdressBook _service ;
        public AdressBookController(IAdressBook service)
        {
            _service = service;
        }

        [HttpGet()]
        public async Task<IEnumerable<models.Concact>> GetAll()
        {
            return await _service.GetConcactsAsync();
        }
    }
}
