<template>
    <section v-if="customSection" class="custom-section">
        <div class="row mb-2">
            <div class="col form-group">
                <input type="text" v-model="customSection.name" class="form-control mb-2" placeholder="Nom de la section personnalisée" />
            </div>
            <div class="col form-group">
                <input v-model="customSection.description" class="form-control" placeholder="Description de la section personnalisée" />
            </div>
        </div>
        
        <hr/>
        
        <div v-if="customSection.customProperties" class="row properties">
            <template v-for="(property, index) in customSection.customProperties">
                <div :class="`col-3 custom-property ${(((index+1) % 4 === 0) || (index === customSection.customProperties.length-1)) ? 'last-property' : ''}`">
                    <custom-property :value="property"></custom-property>
                </div>
            </template>
        </div>
        <div class="row mt-2">
            <div class="text-center btn-add-property">
                <button type="button" class="btn btn-primary" @click="addNewProperty">Ajouter une propriété</button>
            </div>
        </div>
    </section>
</template>

<script>
    import {CustomSection} from "../../Models/CustomSection";
    import {CustomProperty} from "../../Models/CustomProperty";
    
    export default {
        name: "CustomSection",
        props: {
            section: {
                type: CustomSection
            }
        },
        data() {
            return {
                customSection: CustomSection
            }
        },
        mounted() {
            if (this.section) {
                this.customSection = this.section;
                if (!this.customSection.customProperties.length) {
                    this.customSection.customProperties.push(new CustomProperty());
                }
            }
        },
        methods: {
            addNewProperty() {
                let property = new CustomProperty();
                this.customSection.customProperties.push(property);
            }
        }
    }
</script>
