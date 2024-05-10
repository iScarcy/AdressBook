using AdressBook.Api.Services.Interface;
using AdressBook.Api.Services.Service;
using AdressBook.Api.Settings;
using System.Drawing;

namespace AdressBook.Api.Services
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddAdressBookDatabaseService(this IServiceCollection service, IConfigurationSection adressBookDatabaseSection)
        {
            service.Configure<AdressBookDatabaseSettings>(adressBookDatabaseSection);

            service.AddScoped<IRepository<Models.Concact>, ContactsRepositoryService>();
            service.AddScoped<IAdressBook, AdressBookService>();
 
            return service;
        }

        public static IServiceCollection AddRecurringEventsService(this IServiceCollection service, IConfigurationSection recurringEventsSection)
        {
            
            service.Configure<RecurringEventSettings>(recurringEventsSection);
 
            service.AddScoped<IRecurringEvents, RecurringEventsService>();

            return service;
        }
    }
}
