<template>
    <div>
        <div class="row">
            <div class="col form-group">
                <input v-model="property.name" class="form-control" placeholder="Nom de la propriété" />
            </div>
        </div>
        <div class="row mt-2">
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
        </div>
        <div class="row mt-2">
            <div class="col form-group">
                <input v-model="property.valeur" class="form-control" placeholder="Valeur" />
            </div>
            <div class="col form-group">
                <input v-model="property.valeurMax" class="form-control" placeholder="Max" />
            </div>
            <div class="col form-group">
                <input v-model="property.unite" class="form-control" placeholder="Unité" />
            </div>
        </div>
    </div>
</template>

<script>

import {CustomProperty} from "../../Models/CustomProperty";
import {CustomPropertyType} from "../../Models/CustomPropertyType";

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
        }
    }
}
</script>
