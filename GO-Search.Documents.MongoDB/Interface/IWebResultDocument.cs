using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace GO_Search.Documents.MongoDB.Interface
{
    public interface IWebResultDocument
    {
        [BsonId]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime DatePublished { get; set; }
        public string Snippet { get; set; }
    }
}
