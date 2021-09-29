import {Character} from "./Character";
import {CustomProperty} from "./CustomProperty";

export class CustomSection {
    public id: number;
    public name: string;
    public description: string;
    public character: Character;
    public customProperties: CustomProperty[];

    constructor(data?) {
        if (data) {
            this.id = data.id;
            this.name = data.name;
            this.description = data.description;
            this.character = new Character(data.character);
            this.customProperties = data.customProperties ? data.customProperties.map(_ => new CustomProperty(_)) : [];
        } else {
            this.customProperties = [];
        }
    }
}