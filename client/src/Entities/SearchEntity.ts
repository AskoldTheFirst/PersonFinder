import { SearchParamsDto } from "../DTOs/SearchParamsDto";

export class SearchEntity {
    public constructor() {
        this.abilityChoice = 1;
        this.abilityKeyWords = '';
        this.locationChoice = 1;
        this.country = '';
        this.region = '';
        this.languageChoice = 1;
        this.ageId = 1;

        this.isAbilityValid = true;
        this.isCountryValid = true;
        this.isRegionValid = true;
    }

    abilityChoice: number;
    abilityKeyWords: string;
    locationChoice: number;
    country: string;
    region: string;
    languageChoice: number;
    ageId: number;

    isAbilityValid: boolean;
    isCountryValid: boolean;
    isRegionValid: boolean;

    public validateAbility(): void {
        this.isAbilityValid = this.abilityKeyWords.length > 0;
    }

    public validateCountry(): void {
        this.isCountryValid = this.locationChoice != 2 || this.country.length > 0;
    }

    public validateRegion(): void {
        this.isRegionValid = this.locationChoice != 2 || this.region.length > 0;
    }

    public validateEntireModel(): void {

        this.validateAbility();
        this.validateCountry();
        this.validateRegion();
    }

    public isValid(): boolean {
        this.validateEntireModel();
        return this.isAbilityValid && this.isCountryValid && this.isRegionValid;
    }

    public clone(): SearchEntity {
        let newEntity = new SearchEntity();

        newEntity.abilityChoice = this.abilityChoice;
        newEntity.abilityKeyWords = this.abilityKeyWords;
        newEntity.locationChoice = this.locationChoice;
        newEntity.country = this.country;
        newEntity.region = this.region;
        newEntity.languageChoice = this.languageChoice;
        newEntity.ageId = this.ageId;

        newEntity.isAbilityValid = this.isAbilityValid;
        newEntity.isCountryValid = this.isCountryValid;
        newEntity.isRegionValid = this.isRegionValid;

        return newEntity;
    }

    public toDto(): SearchParamsDto {
        return {
            abilityChoice: this.abilityChoice,
            abilityKeyWords: this.abilityKeyWords,
            locationChoice: this.locationChoice,
            locationCountry: this.country,
            locationRegion: this.region,
            languageChoice: this.languageChoice,
            ageChoice: this.ageId
        }
    }
}