using AdressBook.Api.Controllers.Models;
using AdressBook.Api.Models;
using AdressBook.Api.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using models = AdressBook.Api.Models;

namespace AdressBook.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdressBookController : Controller
    {
        private readonly IAdressBook _serviceAddrBook ;
        private readonly IRecurringEvents _serviceEvents;
        public AdressBookController(IAdressBook serviceAddrBook, IRecurringEvents serviceEvents)
        {
            _serviceAddrBook = serviceAddrBook;
            _serviceEvents = serviceEvents;
        }

        [HttpGet()]
        public async Task<IEnumerable<models.Contact>> GetAll()
        {
            return await _serviceAddrBook.GetConcactsAsync();
        }

        [HttpGet("{Id}")]
        public async Task<models.Contact> Get(string Id)
        {
            return await _serviceAddrBook.GetConcactAsync(Id);
        }

        [HttpPost()]
        public async Task<ContactCreateResponse> Insert(models.Contact contact)
        {
            ContactCreateResponse responseCreate = await _serviceAddrBook.InsertAsync(contact);       
            
            if(!string.IsNullOrWhiteSpace(responseCreate.ObjID))
            {
                Person person = new Person { BirthDay = contact.DataNascita, FullName = contact.Nome + " " + contact.Cognome, ObjIdRef = responseCreate.ObjID };

                await _serviceEvents.CreatePerson(person);
            }

            return responseCreate;
        }

        [HttpDelete]
        public async Task Delete(string Id)
        {
            await _serviceAddrBook.DeleteContactAsync(Id);
        }

        [HttpPatch]
        public async Task Update(models.Contact contact) 
        { 
            await _serviceAddrBook.UpdateContactAsync(contact);

            if (!string.IsNullOrWhiteSpace(contact.Id)) 
            {
                ChangeDateRequest request = new ChangeDateRequest { objID = contact.Id, newBirthDay = contact.DataNascita };

                await _serviceEvents.ChangeBirthDay(request);
            }
            
        }

        [HttpPatch("ChangeBirthDay")]
        public async Task ChangeBirthDay(ChangeDateRequest request)
        {
            models.Contact contact = await _serviceAddrBook.GetConcactAsync(request.objID);
            if(contact!= null)
            {
                contact.DataNascita = request.newBirthDay;
                await _serviceAddrBook.UpdateContactAsync(contact);
                await _serviceEvents.ChangeBirthDay(request);
            }

        }
    }
}
 