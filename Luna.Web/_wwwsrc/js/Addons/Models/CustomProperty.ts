import {CustomPropertyType} from "./CustomPropertyType";
import {Race} from "./Race";

export class CustomProperty {
    public id: number;
    public name: string;
    public description: string;
    public type: CustomPropertyType;
    public race: Race;
    public valeur: number;
    public valeurMax: number;
    public unite: string;

    constructor(data?) {
        if (data) {
            this.id = data.id;
            this.name = data.name;
            this.description = data.description;
            this.type = data.type ? new CustomPropertyType(data.type) : null;
            this.race = data.race;
            this.valeur = data.valeur;
            this.valeurMax = data.valeurMax;
            this.unite = data.unite;
        }
    }
}