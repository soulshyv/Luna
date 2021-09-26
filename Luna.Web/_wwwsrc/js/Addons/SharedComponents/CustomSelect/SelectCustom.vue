<template>
    <div>
        <div class="row">
            <div class="col-md-1">
                <button v-if="urlNewOption" type="button" class="btn btn-sm btn-primary" @click="toggleModal" style="height: 100%"><i class="fa fa-plus"></i></button>
            </div>
            <div :class="`col-md-${urlNewOption ? '11' : '12'}`">
                <v-select class="" v-model="selection" :id="id" :name="name" :multiple="multiple" :options="options" :placeholder="placeholder" @chance="select" v-on:reset="reset">
                    <template slot="option" slot-scope="option">
                        <span>{{ option.text }}</span>
                    </template>
                </v-select>
                <input v-if="selection" type="hidden" :value="selection.map(_ => _.value)">
            </div>
        </div>
        <div class="modal fade" :id="`addNewOptionModal-${name}`" tabindex="-1" role="dialog" :aria-labelledby="`addNewOptionModal-${name}Label`" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" :id="`addNewOptionModal-${name}Label`">Ajouter un nouvel élément</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <input type="text" v-model="newOptionName"/>
                        <textarea type="text" v-model="newOptionDescription"></textarea>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Fermer</button>
                        <button type="button" class="btn btn-primary" @click="add">Ajouter</button>
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
            value: {
                type: String,
                default: ""
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
                newOptionDescription: null
            }
        },
        mounted() {
            let $this = this;

            if (this.url) {
                fetch(this.url).then(res => {
                    res.json().then(json => ($this.options = json));
                });
            }

            if (this.value && this.value !== "") {
                this.selection = this.value;
            }
        },
        methods: {
            select(evt) {
                this.$emit('input', evt.target.value);
            },
            reset() {
                this.selection = null;
            },
            toggleModal() {
                $(`#addNewOptionModal-${name}`).modal('toggle');
            },
            add() {
                $.ajax({
                    url: this.urlNewOption,
                    type: 'POST',
                    data: {
                        name: this.newOptionName,
                        description: this.newOptionDescription,
                    }
                });
            }
        }
    }
</script>
