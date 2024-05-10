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

        public async Task DeleteAsync(string id) =>
        await _contactsCollection.DeleteOneAsync(x => x.Id == id);


        public async Task<IEnumerable<Concact>> GetAll()
        {
            return await _contactsCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Concact> GetByID(string ID)
        {
             return await _contactsCollection.Find(x => x.Id == ID).FirstOrDefaultAsync();
        }

        public async Task<Concact> Insert(Concact entity)
        {
            await _contactsCollection.InsertOneAsync(entity);
            return entity;
        }


        public async Task UpdateAsync(Concact entity) =>
            await _contactsCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
    }
}
