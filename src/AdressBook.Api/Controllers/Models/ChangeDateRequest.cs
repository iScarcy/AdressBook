using System.ComponentModel.DataAnnotations;

namespace AdressBook.Api.Controllers.Models;

public class ChangeDateRequest
{
    [Required]
        public DateTime newBirthDay { get; set; }
        [Required]
        public string objID { get; set; }
}
