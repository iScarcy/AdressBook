using AdressBook.Api.Models;

namespace AdressBook.Api.Services.Interface
{
    public interface IRecurringEvents
    {
        Task CreatePerson(Person person);
    }
}
