using System.ComponentModel.DataAnnotations;

namespace WebApi.Database.Entities
{
    public class Card
    {
        public int Id { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [Required]
        public int AbilityChoice { get; set; }

        public string[] AbilityKeyWords { get; set; }

        [Required]
        public int LocationChoice { get; set; }

        public string Country { get; set; }

        public string Region { get; set; }

        [Required]
        public int LanguageChoice { get; set; }

        [Required]
        public int AgeChoice { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
