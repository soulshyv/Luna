import {CustomPropertyType} from "./CustomPropertyType";

export class CustomProperty {
    public id: number;
    public name: string;
    public description: string;
    
    public valeur: number;
    public valeurMax: number;
    public unite: string;
    
    public type: CustomPropertyType;

    constructor(data?) {
        if (data) {
            this.id = data.id;
            this.name = data.name;
            this.description = data.description;
            
            this.valeur = data.valeur;
            this.valeurMax = data.valeurMax;
            this.unite = data.unite;

            this.type = new CustomPropertyType(data.type);
        }
    }
}