using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AdressBook.Api.Models;

public class Concact
{   
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("nome")]
    public string Nome { get; set; } = string.Empty;
    
    [BsonElement("cognome")]
    public string Cognome { get; set; } = string.Empty;

    [BsonElement("dataNascita")]
    public DateTime DataNascita { get; set; } 

    [BsonElement("luogoNascita")]
    public string LuogoNascita { get; set; } = string.Empty;

    [BsonElement("email")]
    public string Email { get; set; } = string.Empty;

    [BsonElement("sesso")]
    public string Sesso { get; set; } = string.Empty; 

    [BsonElement("tel")]
    public string Tel { get; set; } = string.Empty;

    [BsonElement("cell")]
    public string Cell { get; set; } = string.Empty;
}
