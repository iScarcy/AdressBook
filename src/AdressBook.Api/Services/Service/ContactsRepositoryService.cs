using AdressBook.Api.Models;
using AdressBook.Api.Services.Interface;
using AdressBook.Api.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using models = AdressBook.Api.Models;

namespace AdressBook.Api.Services.Service
{
    public class ContactsRepositoryService : IRepository<Contact>
    {
        private readonly IMongoCollection<Contact> _contactsCollection;

        public ContactsRepositoryService(IOptions<AdressBookDatabaseSettings> adressBookDatabase)
        {
            var mongoClient = new MongoClient(
           adressBookDatabase.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                adressBookDatabase.Value.DatabaseName);

            _contactsCollection = mongoDatabase.GetCollection<Contact>(
                adressBookDatabase.Value.AdressBookCollectionName);
          
        }

        public async Task DeleteAsync(string id) =>
        await _contactsCollection.DeleteOneAsync(x => x.Id == id);


        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _contactsCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Contact> GetByID(string ID)
        {
             return await _contactsCollection.Find(x => x.Id == ID).FirstOrDefaultAsync();
        }

        public async Task<Contact> Insert(Contact entity)
        {
            await _contactsCollection.InsertOneAsync(entity);
            return entity;
        }


        public async Task UpdateAsync(Contact entity) =>
            await _contactsCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
    }
}
