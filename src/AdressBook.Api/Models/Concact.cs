using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AdressBook.Api.Models;

public class Concact
{   
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Nome")]
    public string Nome { get; set; } = string.Empty;
    
    [BsonElement("Cognome")]
    public string Cognome { get; set; } = string.Empty;

    [BsonElement("DataNascita")]
    public DateTime DataNascita { get; set; } 

    [BsonElement("LuogoNascita")]
    public string LuogoNascita { get; set; } = string.Empty;

    [BsonElement("Email")]
    public string Email { get; set; } = string.Empty;

    [BsonElement("Sesso")]
    public string Sesso { get; set; } = string.Empty; 

    [BsonElement("Tel")]
    public string Tel { get; set; } = string.Empty;

    [BsonElement("Cell")]
    public string Cell { get; set; } = string.Empty;
}
