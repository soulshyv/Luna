export class CustomField {
    public id: number;
    public name: string;
    public description: string;

    constructor(data?) {
        if (data) {
            this.id = data.id;
            this.name = data.name;
            this.description = data.description;
        }
    }
}