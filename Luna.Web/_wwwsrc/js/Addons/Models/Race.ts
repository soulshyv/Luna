import {CustomProperty} from "./CustomProperty";

export class Race {
    public id: number;
    public name: string;
    public description: string;
    
    public customProperties: CustomProperty[];

    constructor(data?) {
        if (data) {
            this.id = data.id;
            this.name = data.name;
            this.description = data.description;
            
            this.customProperties = data.customProperties ? data.customProperties.map(_ => new CustomProperty(_)) : [];
        } else {
            this.customProperties = [];
        }
    }
}