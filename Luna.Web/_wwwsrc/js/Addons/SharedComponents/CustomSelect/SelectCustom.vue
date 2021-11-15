<template>
    <div>
        <div class="row">
            <div class="col-md-1" v-if="urlNewOption">
                <button type="button"
                        class="btn btn-sm btn-primary"
                        data-bs-toggle="modal"
                        :data-bs-target="`#addNewOptionModal-${name}`"
                        style="height: 100%; border-top-right-radius: 0; border-bottom-right-radius: 0;"
                >
                  <i class="fa fa-plus"></i>
                </button>
            </div>
            <div :class="`col-md-${urlNewOption ? '11' : '12'}`" :style="urlNewOption ? `border-top-left-radius: 0; border-bottom-left-radius: 0; padding-left 0` : ''">
                <v-select :value="selection" class="" v-model="selection" :id="id" :name="name" :multiple="multiple" :options="options" label="text" :placeholder="placeholder" @input="select" v-on:reset="reset">
                    <template slot="option" slot-scope="option">
                        <span>{{ option.text }}</span>
                    </template>
                </v-select>
            </div>
        </div>
        <div class="modal fade" :id="`addNewOptionModal-${name}`" tabindex="-1" role="dialog" :aria-labelledby="`addNewOptionModal-${name}Label`" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" :id="`addNewOptionModal-${name}Label`">Ajouter un nouvel élément</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body form-group">
                        <div v-if="errorMessage" class="row mb-2">
                            <div class="col-md-12 alert alert-danger">
                                <span>{{ errorMessage }}</span>
                            </div>
                        </div>
                        <div class="row mb-2">
                            <div class="col-md-12">
                                <input type="text" class="form-control" v-model="newOptionName" placeholder="Nom" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <textarea type="text" class="form-control" v-model="newOptionDescription" placeholder="Description" ></textarea>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Fermer</button>
                        <button type="button" class="btn btn-success" @click="add">Ajouter</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import vSelect from "vue-select";

    export default {
        name: "SelectCustom",
        components: { vSelect },
        props: {
            name: {
                type: String,
                default: ""
            },
            id: {
                type: String,
                default: ""
            },
            multiple: {
                type: Boolean,
                default: false
            },
            url: {
                type: String,
                default: ""
            },
            optionsList: {
                type: Array
            },
            defaultValue: {
                type: String
            },
            placeholder: {
                type: String,
                default: ""
            },
            urlNewOption: {
                type: String,
                default: null
            }
        },
        data() {
            return {
                options: [],
                selection: null,
                newOptionName: null,
                newOptionDescription: null,
                errorMessage: null
            }
        },
        mounted() {
            let $this = this;

            if (this.url) {
                fetch(this.url).then(res => {
                    res.json().then(json => {
                        $this.options = json;
                        $this.selection = $this.defaultValue ? json.find(_ => _.value === this.defaultValue) : null;
                    });
                });
            }
        },
        methods: {
            select() {
                this.$emit('input', this.selection);
            },
            reset() {
                this.selection = null;
            },
            toggleModal() {
                $(`#addNewOptionModal-${this.name}`).modal('toggle');
            },
            add() {
                if (!this.newOptionName || !this.newOptionName.length) {
                    return;
                }
                
                let $this = this;
                
                $.ajax({
                    url: this.urlNewOption,
                    type: 'POST',
                    data: {
                        name: $this.newOptionName,
                        description: $this.newOptionDescription,
                    }
                }).done(function(data) {
                    $this.errorMessage = null;

                    if ($this.url) {
                        fetch($this.url).then(res => {
                            res.json().then(json => ($this.options = json));
                        });
                    }

                    $this.toggleModal();
                    $this.newOptionName = "";
                    $this.newOptionDescription = "";
                }).fail(function(data) {
                    $this.errorMessage = "L'entité n'a pas pu être ajoutée";
                });
            }
        }
    }
</script>
