using System.ComponentModel.DataAnnotations;

namespace WebApi.Database.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }

        public int[] CardIds { get; set; }

        [Required]
        public string Login { get; set; }

        public string About { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ContactCellPhone { get; set; }

        public string ContactEmail { get; set; }

        public string[] ContactLinks { get; set; }
    }
}
