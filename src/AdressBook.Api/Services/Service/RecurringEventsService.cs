using AdressBook.Api.Models;
using AdressBook.Api.Services.Interface;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using System.Text;
using AdressBook.Api.Settings;
using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using AdressBook.Api.Controllers.Models;

namespace AdressBook.Api.Services.Service
{
    public class RecurringEventsService : IRecurringEvents
    {
        private HttpClient _client = new();
        private RecurringEventSettings _settingsAPI;
        public RecurringEventsService(IOptions<RecurringEventSettings> settings)
        {

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            _client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            _settingsAPI = settings.Value;
        }
        public async Task CreatePerson(Person person)
        {
            
            using StringContent jsonContent = new(
              JsonSerializer.Serialize(person),
              Encoding.UTF8,
              "application/json");

            using HttpResponseMessage response = await _client.PostAsync(
           _settingsAPI.UriRecurringEvent + _settingsAPI.ApiPersonWasCreated,
           jsonContent);

            
        }

        public async Task ChangeBirtDayDete(ChangeDateRequest request)
        {
            
            using StringContent jsonContent = new(
              JsonSerializer.Serialize(request),
              Encoding.UTF8,
              "application/json");

            using HttpResponseMessage response = await _client.PatchAsync(
           _settingsAPI.UriRecurringEvent + _settingsAPI.ApiChangeBirtDayDete,
           jsonContent);

            
        }
    }
}
