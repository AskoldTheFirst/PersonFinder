using MongoDB.Bson;

namespace WebApi.DTOs
{
    public class SearchResultDto
    {
        public ObjectId CardId { get; set; }
        
        public string Login { get; set; }

        public string[] MatchedParams { get; set; }

        public string[] NotMatchedParams { get; set; }
    }
}
