export class CustomField {
    public id: number;
    public name: string;
    public description: string;
    public valeur: string;

    constructor(data?) {
        if (data) {
            this.id = data.id;
            this.name = data.name;
            this.description = data.description;
            this.valeur = data.valeur;
        }
    }
}