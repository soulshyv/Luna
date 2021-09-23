import {CharacterType} from "./CharacterType";
import {Race} from "./Race";
import {CustomProperty} from "./CustomProperty";

export class Character {
    public id: number;
    public name: string;
    public description: string;
    public type: CharacterType;
    public race: Race;
    public customProperties: CustomProperty[];
    
    constructor(data?) {
        if (data) {
            this.id = data.id;
            this.name = data.name;
            this.description = data.description;
            this.type = data.type ? new CharacterType(data.type) : null;
            this.race = data.race ? new Race(data.race) : null;
            this.customProperties = data.customProperties ? data.customProperties.map(_ => new CustomProperty(_)) : [];
        }
    }
}