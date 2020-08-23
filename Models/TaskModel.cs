using MongoDB.Bson; 
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace mongo_dotnet_ep1.Models
{
    public class TaskModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonElement("descricao")]
        public string Descricao { get; set; }          
        [BsonElement("prioridade")]
        public string Prioridade { get; set; }
        [BsonElement("ativo")]
        public bool Ativo { get; set; }
    }
}