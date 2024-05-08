namespace AdressBook.Api.Settings
{
    public class AdressBookDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string AdressBookCollectionName { get; set; } = null!;
    }
}
