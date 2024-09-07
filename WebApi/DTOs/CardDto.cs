using MongoDB.Bson;

namespace WebApi.DTOs
{
    public class CardDto : SearchParamsDto
    {
        public string OwnerLogin { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool IsActive { get; set; }

        // public ObjectId CardId { get; set; }

        // public ObjectId OwnerId { get; set; }
    }
}