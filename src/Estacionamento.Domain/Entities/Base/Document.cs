using MongoDB.Bson;
using Newtonsoft.Json;

namespace Estacionamento.Domain.Entities.Base
{
    public class Document : IDocument
    {

        public Document()
        {
            Id = ObjectId.GenerateNewId();
        }
        [JsonIgnore]
        public ObjectId Id { get; set; }

    }
}
