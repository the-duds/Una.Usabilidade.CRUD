using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Estacionamento.Domain.Entities.Base
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }
    }
}
