using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace WebApi.Database.Entities
{
    public class Message
    {
        public ObjectId Id { get; set; }

        [Required]
        public int FromId { get; set; }

        [Required]
        public int ToId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime SentDate { get; set; }
    }
}