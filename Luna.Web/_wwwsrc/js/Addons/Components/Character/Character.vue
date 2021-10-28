<template>
    <form>
        <div class="row">
            <div class="col-md-8 offset-md-2">
                <div class="row form-group mb-2">
                    <div class="col-md-12">
                        <input type="text" v-model="character.name" class="form-control required" placeholder="Nom du personnage"/>
                    </div>
                </div>
                <div class="row form-group mb-2">
                    <div class="col-md-12">
                        <textarea type="text" v-model="character.description" class="form-control required" placeholder="Description du personnage"></textarea>
                    </div>
                </div>
                <div class="row mb-2">
                    <div class="col-md-6">
                        <select-custom
                            v-model="type"
                            url="/Character/GetAllCharacterTypesForSelect"
                            :default-value="typeId"
                            placeholder="Type du personnage"
                            url-new-option="/Character/AddNewCharacterType"
                            name="character_type"
                            class="required">
                        </select-custom>
                    </div>
                    <div class="col-md-6">
                        <select-custom
                            v-model="race"
                            url="/Character/GetAllRacesForSelect"
                            :default-value="raceId"
                            placeholder="Race du personnage"
                            url-new-option="/Character/AddNewRace"
                            name="character_race"
                            class="required">
                        </select-custom>
                    </div>
                </div>
            </div>
            <template v-if="character.customSections">
                <div v-for="section in character.customSections" class="row mb-2">
                    <div class="col-md-12">
                        <custom-section :section="section"></custom-section>
                    </div>
                </div>
            </template>
            <div class="row mb-2">
                <div class="col-md-12 text-center">
                    <button type="button" class="btn btn-primary" @click="addNewSection">Ajouter une section personnalisée</button>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 text-center">
                    <button type="button" class="btn btn-success" @click="save">Enregistrer</button>
                </div>
            </div>
        </div>
    </form>
</template>

<script>
    import $ from "jquery";
    import SelectCustom from "../../SharedComponents/CustomSelect/SelectCustom";
    import {Character} from "../../Models/Character";
    import {CustomSection} from "../../Models/CustomSection";
    import {CharacterType} from "../../Models/CharacterType";
    import {Race} from "../../Models/Race";

    export default {
        name: "Character",
        components: {SelectCustom},
        props: {
            id: Number
        },
        data() {
            return {
                character: Character,
                type: null,
                race: null,
                typeId: null,
                raceId: null
            };
        },
        mounted() {
            if (this.id) {
                let $this = this;
                
                $.ajax({
                    url: `/Character/GetCharacterById/${this.id}`,
                    type: 'GET'
                }).done(function(data) {
                    $this.character = new Character(data);
                    
                    if (data && data.race) {
                        $this.typeId = data.type.id.toString();
                        $this.raceId = data.race.id.toString();
                    }
                });
            } else {
                this.character = new Character();
            }
        },
        methods: {
            addNewSection() {
                this.character.customSections.push(new CustomSection());
            },
            save() {
                $.ajax({
                    url: `/Character/${this.isEdit ? 'Edit' : 'Create'}`,
                    type: 'POST',
                    data: {
                        model: this.character
                    }
                }).done(function(url) {
                    window.location.href = url;
                });
            }
        },
        computed: {
            isEdit() {
                return !!this.id;
            },
            races() {
                let races = null;
                
                $.ajax({
                    url: '/Character/GetAllRacesForSelect',
                    type: 'GET'
                }).done(function(data) {
                    races = data;
                });
                    
                return races;
            },
            characterTypes() {
                let types = null;
                
                $.ajax({
                    url: '/Character/GetAllCharacterTypesForSelect',
                    type: 'GET'
                }).done(function(data) {
                    types = data;
                });
                
                return types;
            }
        },
        watch: {
            type: function(val) {
                let type = new CharacterType();
                type.id = val.value;
                type.name = val.text;
                this.character.type = type;
            },
            race: function(val) {
                let race = new Race();
                race.id = val.value;
                race.name = val.text;
                this.character.race = race;
            }
        }
    }
</script>
