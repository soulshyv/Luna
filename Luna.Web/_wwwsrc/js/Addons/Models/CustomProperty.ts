import {CustomPropertyType} from "./CustomPropertyType";
import {Race} from "./Race";
import {CustomSection} from "./CustomSection";

export class CustomProperty {
    public id: number;
    public name: string;
    public description: string;
    public type: CustomPropertyType;
    public customSection: CustomSection;
    public race: Race;
    public valeur: number;
    public valeurMax: number;
    public unite: string;

    constructor(data?) {
        if (data) {
            this.id = data.id;
            this.name = data.name;
            this.description = data.description;
            this.type = new CustomPropertyType(data.type);
            this.customSection = new CustomSection(data.customSection);
            this.race = data.race;
            this.valeur = data.valeur;
            this.valeurMax = data.valeurMax;
            this.unite = data.unite;
        }
    }
}