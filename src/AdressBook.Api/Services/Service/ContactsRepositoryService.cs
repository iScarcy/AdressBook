using AdressBook.Api.Models;
using AdressBook.Api.Services.Interface;
using AdressBook.Api.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using models = AdressBook.Api.Models;

namespace AdressBook.Api.Services.Service
{
    public class ContactsRepositoryService : IRepository<Concact>
    {
        private readonly IMongoCollection<Concact> _contactsCollection;

        public ContactsRepositoryService(IOptions<AdressBookDatabaseSettings> adressBookDatabase)
        {
            var mongoClient = new MongoClient(
           adressBookDatabase.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                adressBookDatabase.Value.DatabaseName);

            _contactsCollection = mongoDatabase.GetCollection<Concact>(
                adressBookDatabase.Value.AdressBookCollectionName);
          
        }


        public async Task<IEnumerable<Concact>> GetAll()
        {
            return await _contactsCollection.Find(_ => true).ToListAsync();
        }

        public Task<Concact> GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Concact entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Concact entity)
        {
            throw new NotImplementedException();
        }
    }
}
