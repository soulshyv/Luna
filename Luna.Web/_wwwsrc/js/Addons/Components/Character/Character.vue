<template>
    <div class="row form-group">
        <div class="col-md-12">
            <label for="name" class="control-label col-md-2">Nom :</label>
            <div class="col-md-8">
                <input type="text" v-model="character.name" id="name" class="form-control required" />
            </div>
        </div>
    </div>
</template>

<script>
    import {Character} from "../../Models/Character";

    export default {
        data() {
            return {
                character: new Character()
            };
        },
        mounted() {
            
        },
        methods: {
            
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
