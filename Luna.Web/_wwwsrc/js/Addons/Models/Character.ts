import {CharacterType} from "./CharacterType";
import {Race} from "./Race";
import {CustomSection} from "./CustomSection";

export class Character {
    public id: number;
    public name: string;
    public description: string;
    public type: CharacterType;
    public race: Race;
    public customSections: CustomSection[];
    
    constructor(data?) {
        if (data) {
            this.id = data.id;
            this.name = data.name;
            this.description = data.description;
            this.type = new CharacterType(data.type);
            this.race = new Race(data.race);
            this.customSections = data.customSections ? data.customSections.map(_ => new CustomSection(_)) : [];
        } else {
            this.customSections = [];
        }
    }
}