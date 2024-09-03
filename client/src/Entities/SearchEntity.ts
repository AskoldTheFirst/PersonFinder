export class SearchEntity {
    public constructor() {
        this.abilityId = 1;
        this.abilityKeyWords = '';
        this.locationId = 1;
        this.country = '';
        this.region = '';
        this.languageId = 1;
        this.ageId = 1;

        this.isAbilityValid = true;
        this.isCountryValid = true;
        this.isRegionValid = true;
    }

    abilityId: number;
    abilityKeyWords: string;
    locationId: number;
    country: string;
    region: string;
    languageId: number;
    ageId: number;

    isAbilityValid: boolean;
    isCountryValid: boolean;
    isRegionValid: boolean;

    public validate(): void {
        this.isAbilityValid = this.abilityKeyWords.length > 0;
        this.isCountryValid = this.locationId == 2 && this.country.length > 0;
        this.isRegionValid = this.locationId == 2 && this.region.length > 0;
    }
}