<template>
    <div id="character-container" @change="hasChanged = true;" @input="hasChanged = true;">
        <div id="characters" ref="characters">
            <div class="row form-group mb-2">
                <div class="col-md-12">
                    <input type="text" v-model="character.name" class="form-control required" placeholder="Nom du personnage"/>
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
            <div class="row form-group mb-2">
                <div class="col-md-12">
                    <textarea type="text" v-model="character.description" rows="25" class="form-control required" placeholder="Description du personnage"></textarea>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 text-center">
                    <button type="button" class="btn btn-success" @click="save">Enregistrer</button>
                </div>
            </div>
        </div>
        <div id="dragbar"></div>
        <div id="details" ref="details">
            <div id="sections-list">
                <template v-if="character.customSections">
                    <div v-for="(section, index) in character.customSections" class="row mb-2 section-list-item" :data-index="index" :key="index">
                        <div class="col-md-12">
                            <custom-section :section="section" :section-index="index" @delete="deleteSection(index)"></custom-section>
                        </div>
                    </div>
                </template>
            </div>
            <div class="row mb-2">
                <div class="col-md-12 text-center">
                    <button type="button" class="btn btn-primary" @click="addNewSection">Ajouter une section personnalisée</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import $ from "jquery";
    import Vue from "vue";
    import SelectCustom from "../../SharedComponents/CustomSelect/SelectCustom";
    import {Character} from "../../Models/Character";
    import {CustomSection} from "../../Models/CustomSection";
    import {CharacterType} from "../../Models/CharacterType";
    import {Race} from "../../Models/Race";
    import Sortable from "sortablejs";

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
                raceId: null,
                isDragging: false,
                hasChanged: false
            };
        },
        mounted() {
            let $this = this;

            if (this.id) {
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

            var sectionsList = document.getElementById("sections-list");
            Sortable.create(sectionsList, {
                handle: '.btn-section-move',
                animation: 150,
                onEnd: function(evt) {
                    let allSections = $(".section-list-item");
                    for (let i = 0; i < allSections.length; i++) {
                        let el = $(allSections[i]);
                        let index = el.data("index");
                        if (index === undefined || index === null) {
                            continue;
                        }

                        $this.character.customSections[index].order = i;
                    }
                    
                    $this.hasChanged = true;
                }
            });

            this.loadDragbarPreferences();
        },
        methods: {
            loadDragbarPreferences() {
                let documentCookies = document.cookie;
                if (!documentCookies){
                    return;
                }
                
                let cookies = document.cookie.split("; ");

                let cookie = cookies.find(c => c.includes("dragbar="));
                if (!cookie) {
                    return;
                }

                let value = JSON.parse(cookie.split("=")[1]);

                this.$refs.characters.style.width = value.charactersWidth + "px";
                this.$refs.details.style.width = value.detailsWidth + "px";
            },
            addNewSection() {
                let customSection = new CustomSection();
                customSection.order = this.character.customSections.length;
                this.character.customSections.push(customSection);
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
            },
            deleteSection(index){
                this.character.customSections.splice(index, 1);
                this.$forceUpdate();
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
