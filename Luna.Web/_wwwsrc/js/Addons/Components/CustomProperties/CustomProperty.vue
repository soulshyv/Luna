<template>
    <div>
        <div class="row">
            <div style="width: 25px; padding-right: 35px;">
                <button class="btn btn-secondary btn-property-move" style="cursor: grab"><i class="fa fa-arrows-alt"></i></button>
            </div>
            <div class="col form-group">
                <input v-model="property.name" class="form-control" placeholder="Nom de la propriété" />
            </div>
            <div class="col">
                <select-custom
                    v-model="type"
                    url="/Character/GetAllCustomPropertyTypesForSelect"
                    :default-value="typeId"
                    placeholder="Type de la propriété"
                    name="type"
                    class="required">
                </select-custom>
            </div>
            <div class="col form-group" v-for="(customPropertyHasCustomField, index) in property.customPropertyHasCustomFields" :key="index">
                <input class="form-control" :placeholder="customPropertyHasCustomField.field.name" v-model="property.customPropertyHasCustomFields[index].valeur" />
            </div>
            <div class="col-1">
                <button class="btn btn-danger" @click="$emit('delete')"><i class="fa fa-trash"></i></button>
            </div>
        </div>
    </div> 
</template>

<script>

import {CustomProperty} from "../../Models/CustomProperty";
import {CustomPropertyType} from "../../Models/CustomPropertyType";
import $ from "jquery";
import {Character} from "../../Models/Character";
import {CustomField} from "../../Models/CustomField";
import {CustomPropertyHasCustomFields} from "../../Models/CustomPropertyHasCustomFields";

export default {
    name: "CustomProperty",
    props: {
        value: {
            type: CustomProperty,
        }
    },
    data() {
        return {
            property: CustomProperty,
            type: null,
            typeId: null
        }
    },
    mounted() {
        if (this.value) {
            this.property = this.value;
            
            if (this.value.type) {
                this.typeId = this.value.type.id.toString();
            }
        } else {
            this.property = new CustomProperty();
        }
    },
    watch: {
        type: function(val) {
            let type = new CustomPropertyType();
            type.id = val.value;
            type.name = val.text;
            this.property.type = type;

            let $this = this;
            $.ajax({
                url: `/Character/LoadCustomFieldsForType/${val.value}`,
                type: 'GET'
            }).done(function(data) {
                if (data) {
                    let fields = data.map(_ => new CustomField(_));
                    
                    let customPropertyHasCustomFields = [];
                    for (let i = 0; i < fields.length; i++) {
                        let field = fields[i];
                        
                        let customPropertyHasCustomField = new CustomPropertyHasCustomFields();
                        customPropertyHasCustomField.valeur = null;
                        customPropertyHasCustomField.field = field;
                        
                        customPropertyHasCustomFields.push(customPropertyHasCustomField);
                    }
                    $this.property.customPropertyHasCustomFields = customPropertyHasCustomFields;

                    $this.$forceUpdate();
                }
            });
        },
        value: function() {
            this.property = this.value;
        }
    }
}
</script>
