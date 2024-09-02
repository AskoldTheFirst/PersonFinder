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

        public int[] LocationCountries { get; set; }

        public string[] LocationRegions { get; set; }

        [Required]
        public int[] Languages { get; set; }

        [Required]
        public int MinAge { get; set; }

        [Required]
        public int MaxAge { get; set; }

        [Required]
        public int ActiveNumber { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
