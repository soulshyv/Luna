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
                            v-model="character.type"
                            url="/Character/GetAllCharacterTypesForSelect"
                            placeholder="Type du personnage"
                            url-new-option="/Character/AddNewCharacterType"
                            name="character_type"
                            class="required">
                        </select-custom>
                    </div>
                    <div class="col-md-6">
                        <select-custom
                            v-model="character.race"
                            url="/Character/GetAllRacesForSelect"
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
            <div class="row">
                <div class="col-md-12 text-center">
                    <button type="button" class="btn btn-primary" @click="addNewSection">Ajouter une section personnalisée</button>
                </div>
            </div>
        </div>
    </form>
</template>

<script>
    import {Character} from "../../Models/Character";
    import {CustomSection} from "../../Models/CustomSection";
    import SelectCustom from "../../SharedComponents/CustomSelect/SelectCustom";

    export default {
        name: "Character",
        components: {SelectCustom},
        props: {
            id: Number
        },
        data() {
            return {
                character: Character
            };
        },
        mounted() {
            if (this.id) {
                let $this = this;
                $.ajax({
                    url: '/Character/GetCharacterById',
                    type: 'GET'
                }).done(function(data) {
                    $this.character = data;
                });
            } else {
                let character = new Character();
                character.customSections.push(new CustomSection());
                this.character = character;
            }
        },
        methods: {
            addNewSection() {
                this.character.customSections.push(new CustomSection());
            }
        },
        computed: {
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
        }
    }
</script>
