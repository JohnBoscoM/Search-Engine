using GO_Search.Documents.MongoDB.Interface;
using MongoDB.Bson.Serialization.Attributes;


namespace GO_Search.Documents.MongoDB
{
    public class WebPageResultDocument: IWebResultDocument
    {
        [BsonId] 
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime DatePublished { get; set; }
        public string DatePublishedDisplayText { get; set; }    
        public bool IsFamilyFriendly { get; set; }  
        public string DisplayUrl { get; set; }
        public string Snippet { get; set; }
        public string Language { get; set; }
    }
}