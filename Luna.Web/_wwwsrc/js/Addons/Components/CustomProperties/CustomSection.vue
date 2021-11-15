<template>
    <section v-if="customSection" class="custom-section">
        <div class="row mb-2">
            <div style="width: 25px; padding-right: 35px;">
                <button class="btn btn-secondary btn-section-move" style="cursor: grab"><i class="fa fa-arrows-alt"></i></button>
            </div>
            <div class="col form-group">
                <input type="text" v-model="customSection.name" class="form-control mb-2" placeholder="Nom de la section personnalisée" />
            </div>
            <div class="col form-group">
                <input v-model="customSection.description" class="form-control" placeholder="Description de la section personnalisée" />
            </div>
            <div class="col-1 form-group">
              <button class="btn btn-danger" @click="$emit('delete')"><i class="fa fa-trash"></i></button>
            </div>
        </div>
        
        <hr/>
        
        <div class="row properties" ref="propertyList">
            <template v-for="(property, index) in customSection.customProperties">
                <div :class="`col-md-12 mb-2 property-list-item-${sectionIndex}`" :data-index="index" :key="index">
                    <custom-property :value="property" @delete="deleteProperty(index)"></custom-property>
                </div>
            </template>
        </div>
        <div class="row mt-1">
            <div class="text-center btn-add-property">
                <button type="button" class="btn btn-primary" @click="addNewProperty">Ajouter une propriété</button>
            </div>
        </div>
    </section>
</template>

<script>
    import Sortable from 'sortablejs';

    import {CustomSection} from "../../Models/CustomSection";
    import {CustomProperty} from "../../Models/CustomProperty";
    import $ from "jquery";
    
    export default {
        name: "CustomSection",
        props: {
            section: {
                type: CustomSection
            },
            sectionIndex: {
                type: Number
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
            
            let $this = this;
            
            var propertiesList = this.$refs.propertyList;
            if (propertiesList) {
                Sortable.create(propertiesList, {
                    handle: '.btn-property-move',
                    animation: 150,
                    onEnd: function(evt) {
                        let allProperties = $(`.property-list-item-${$this.sectionIndex}`);
                        for (let i = 0; i < allProperties.length; i++) {
                            let el = $(allProperties[i]);
                            let index = el.data("index");
                            if (index === undefined || index === null) {
                                continue;
                            }

                            $this.customSection.customProperties[index].order = i;
                        }

                        // On emit un event change pour notifier que de la data a bougé
                        $this.$emit("change");
                    }
                });
            }
        },
        methods: {
            addNewProperty() {
                let property = new CustomProperty();
                property.order = this.customSection.customProperties.length;
                this.customSection.customProperties.push(property);
            },
            deleteProperty(index){
                this.customSection.customProperties.splice(index, 1);
                this.$forceUpdate();
            }
        },
        watch: {
            section: function() {
                this.customSection = this.section;

                if (!this.customSection.customProperties.length) {
                    this.customSection.customProperties.push(new CustomProperty());
                }
            }
        }
    }
</script>
