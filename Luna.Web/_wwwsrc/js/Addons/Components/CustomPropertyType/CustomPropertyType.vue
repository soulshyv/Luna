<template>
    <div>
        <div class="row mb-2">
            <div class="col-md-12">
                <div class="form-group">
                    <input type="text" v-model="type.name" class="form-control" placeholder="Nom"/>
                </div>
            </div>
        </div>
        <div class="row mb-2">
            <div class="col-md-12">
                <div class="form-group">
                    <textarea v-model="type.description" class="form-control" placeholder="Description"></textarea>
                </div>
            </div>
        </div>
        <template v-if="type.fields && type.fields.length">
            <div class="row mb-2">
                <div class="col-md-12 text-center">
                    <h4>Champs</h4>
                </div>
            </div>
            <template v-for="(field, index) in type.fields">
                <div class="row mb-2" :key="index">
                    <div class="col-md-1">
                        <button class="btn btn-danger" @click="deleteField(index)"><i class="fa fa-trash"></i></button>
                    </div>
                    <div class="col-md-5">
                        <div class="form-group">
                            <input type="text" v-model="field.name" class="form-control" placeholder="Nom du champ" />
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <input type="text" v-model="field.description" class="form-control" placeholder="Description du champ" />
                        </div>
                    </div>
                </div>
            </template>
        </template>
        <div class="row mb-2">
            <div class="col-md-12">
                <div class="form-group text-center">
                    <button type="button" class="btn btn-primary btn-sm" @click="addField">Ajouter un champ</button>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 text-center">
                <button type="button" class="btn btn-success" @click="save">Enregistrer</button>
                <a href="/Admin/CustomPropertyType" class="btn btn-secondary">Annuler</a>
            </div>
        </div>
    </div>
</template>

<script>
import {CustomPropertyType} from "../../Models/CustomPropertyType";
import {CustomField} from "../../Models/CustomField";
import $ from "jquery";

export default {
    name: "CustomPropertyType",
    props: {
        id: {
            type: Number
        }
    },
    data() {
        return {
            type: CustomPropertyType
        }
    },
    computed: {
        isEdit() {
            return !!this.id;
        }
    },
    mounted() {
        if (this.id) {
            let $this = this;
            
            $.ajax({
                url: `/Admin/CustomPropertyType/GetTypeById/${this.id}`,
                type: 'GET'
            }).done(function(data) {
                $this.type = new CustomPropertyType(data);
            });
        } else {
            this.type = new CustomPropertyType();
        }
    },
    methods: {
        save() {
            let url = `/Admin/CustomPropertyType/${this.isEdit ? 'Update' : 'Create'}`;
            
            let $this = this;

            $.ajax({
                url: url,
                type: 'POST',
                data: {
                    model: this.type
                }
            }).done(function(url) {
                window.location.href = url;
            });
        },
        addField() {
            if (!this.type.fields) {
                this.type.fields = [];
            }

            this.type.fields.push(new CustomField());
        },
        deleteField(index) {
            this.type.fields.splice(index, 1);
        }
    }
}
</script>

<style scoped>

</style>