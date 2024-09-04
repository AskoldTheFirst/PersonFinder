namespace WebApi.DTOs
{
    public class SearchParamsDto
    {
        public int AbilityChoice { get; set; }

        public string AbilityKeyWords { get; set; }

        public int LocationChoice { get; set; }

        public string LocationCountry { get; set; }

        public string LocationRegion { get; set; }

        public int LanguageChoice { get; set; }

        public int AgeChoice {get; set;}
    }
}
