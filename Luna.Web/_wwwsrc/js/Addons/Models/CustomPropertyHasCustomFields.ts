import {CustomField} from "./CustomField";

export class CustomPropertyHasCustomFields {
    public id: number;

    public valeur: string;
    
    public field: CustomField

    constructor(data?) {
        if (data) {
            this.id = data.id;

            this.valeur = data.valeur;

            this.field = new CustomField(data.field);
        }
    }
}