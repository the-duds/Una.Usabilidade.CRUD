using System;
using System.Collections.Generic;
using System.Text;

namespace Estacionamento.Domain.Dto.Config
{
    public class MongoDbSettings : IMongoDbSettings
    {

        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }

    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
