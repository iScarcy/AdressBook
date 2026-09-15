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
        public AdressBookController(IAdressBook serviceAddrBook)
        {
            _serviceAddrBook = serviceAddrBook;
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
                //qui dovrei mandare un messagio su kafka sul topic addressbook con i dati dell'evento PersonCreated, i
                // n questo modo il servizio eventi può creare la persona e schedulare l'evento ricorrente per il compleanno
                //Person person = new Person { BirthDay = contact.DataNascita, FullName = contact.Nome + " " + contact.Cognome, ObjIdRef = responseCreate.ObjID };

                //await _serviceEvents.CreatePerson(person);
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
               
               //TODO: INVIARE MESSAGGIO SU RABBIT PER L'AGGIORNAMENTO 
            }
            
        }

      
    }
}
 