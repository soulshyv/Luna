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
                    v-model="property.type"
                    url="/Character/GetAllCustomPropertyTypesForSelect"
                    placeholder="Type de la propriété"
                    url-new-option="/Character/AddNewCustomPropertyType"
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

export default {
    name: "CustomProperty",
    props: {
        value: {
            type: CustomProperty
        }
    },
    data() {
        return {
            property: CustomProperty
        }
    },
    mounted() {
        if (this.value) {
            this.property = this.value;
        }
    },
    methods: {

    }
}
</script>
