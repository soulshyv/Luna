import {CustomPropertyType} from "./CustomPropertyType";
import {CustomPropertyHasCustomFields} from "./CustomPropertyHasCustomFields";

export class CustomProperty {
    public id: number;
    public name: string;
    public description: string;
    
    public order: number;
    
    public type: CustomPropertyType;

    public customPropertyHasCustomFields: CustomPropertyHasCustomFields[];

    constructor(data?) {
        if (data) {
            this.id = data.id;
            this.name = data.name;
            this.description = data.description;
            
            this.order = data.order;

            this.type = new CustomPropertyType(data.type);
            this.customPropertyHasCustomFields =
                data.customPropertyHasCustomFields ?
                data.customPropertyHasCustomFields.map(_ => new CustomPropertyHasCustomFields(_)) :
                [];
        }
    }
}