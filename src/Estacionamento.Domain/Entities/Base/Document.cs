using MongoDB.Bson;
using Newtonsoft.Json;

namespace Estacionamento.Domain.Entities.Base
{
    public class Document : IDocument
    {
        
        [JsonIgnore]
        public ObjectId Id { get; set; }

    }
}
