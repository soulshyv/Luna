import {CustomField} from "./CustomField";

export class CustomPropertyType {
    public id: number;
    public name: string;
    public description: string;
    
    public fields: CustomField[];

    constructor(data?) {
        if (data) {
            this.id = data.id;
            this.name = data.name;
            this.description = data.description;

            this.fields = data.fields ? data.fields.map(_ => new CustomField(_)) : [];
        } else {
            this.fields = [];
        }
    }
}