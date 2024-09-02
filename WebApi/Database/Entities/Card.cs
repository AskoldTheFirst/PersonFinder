namespace WebApi.Database.Entities
{
    public class Card
    {
        public int Id { get; set; }

        public int OwnerId { get; set; }

        public int AbilityChoice { get; set; }

        public string[] AbilityKeyWords { get; set; }

        public int LocationChoice { get; set; }

        public int[] LocationCountries { get; set; }

        public string[] LocationRegions { get; set; }

        public int[] Languages { get; set; }

        public int MinAge { get; set; }

        public int MaxAge { get; set; }

        public int ActiveNumber { get; set; }

        public bool IsActive { get; set; }
    }
}
